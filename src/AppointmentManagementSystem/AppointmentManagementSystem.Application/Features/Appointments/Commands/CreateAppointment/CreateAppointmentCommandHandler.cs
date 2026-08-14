using AppointmentManagementSystem.Application.Common.Settings;
using AppointmentManagementSystem.Application.Interfaces.ExternalServices;
using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandHandler
    : IRequestHandler<CreateAppointmentCommand, Guid>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorWorkingHourRepository _doctorWorkingHourRepository;
    private readonly IDoctorLeaveRepository _doctorLeaveRepository;
    private readonly INotificationRepository _notificationRepository;
    private readonly IPatientPriorityService _patientPriorityService;
    private readonly AppointmentSettings _appointmentSettings;

    public CreateAppointmentCommandHandler(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IDoctorWorkingHourRepository doctorWorkingHourRepository,
        IDoctorLeaveRepository doctorLeaveRepository,
        INotificationRepository notificationRepository,
        IPatientPriorityService patientPriorityService,
        IOptions<AppointmentSettings> appointmentSettings)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _doctorWorkingHourRepository = doctorWorkingHourRepository;
        _doctorLeaveRepository = doctorLeaveRepository;
        _notificationRepository = notificationRepository;
        _patientPriorityService = patientPriorityService;
        _appointmentSettings = appointmentSettings.Value;
    }

    public async Task<Guid> Handle(
        CreateAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.PatientId);

        if (patient is null)
            throw new Exception("Patient not found.");

        var isPriorityPatient = false;

        if (request.HasPriorityRequest)
        {
            isPriorityPatient =
                await _patientPriorityService
                    .IsPriorityPatientAsync(patient.IdentityNumber);
        }

        if (request.HasPriorityRequest && !isPriorityPatient)
        {
            throw new Exception(
                "Özel durumunuz doğrulanamadı. Normal randevu kuralları uygulanacaktır.");
        }

        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        if (doctor is null)
            throw new Exception("Doctor not found.");

        var appointmentDuration = _appointmentSettings.DurationInMinutes;

        var appointmentDate = request.StartTime.Date;
        var today = DateTime.Today;

        if (appointmentDate < today)
            throw new Exception("Appointment cannot be created for a past date.");

        // Normal erişim: 10 gün önce 00:00
        var normalOpenTime = appointmentDate.AddDays(-10);

        // Öncelikli erişim: 6 saat önce
        var priorityOpenTime = normalOpenTime.AddHours(-6);

        var now = DateTime.Now;

        // Doktor iptalinden gelen +5 gün hakkı
        var lastAvailableDate = today.AddDays(10);

        if (patient.ExtraAppointmentUntil.HasValue &&
            patient.ExtraAppointmentUntil.Value.Date > lastAvailableDate)
        {
            lastAvailableDate = patient.ExtraAppointmentUntil.Value.Date;
        }

        // Henüz öncelikli erişim bile başlamadıysa
        if (now < priorityOpenTime)
            throw new Exception("Bu tarih henüz randevuya açılmadı.");

        // Erken erişim dönemindeyiz mi?
        var isPriorityWindow =
            now >= priorityOpenTime &&
            now < normalOpenTime;

        // Erken erişimde normal hasta alamaz
        if (isPriorityWindow && !isPriorityPatient)
        {
            throw new Exception(
                "Bu tarih henüz normal hastalara açılmadı.");
        }

        // Normal erişim başladıktan sonra 10 günlük sınır uygulanır
        if (!isPriorityWindow && appointmentDate > lastAvailableDate)
        {
            throw new Exception(
                $"Appointment can only be created up to {lastAvailableDate:dd.MM.yyyy}.");
        }

        var workingHour =
            await _doctorWorkingHourRepository.GetByDoctorAndDayAsync(
                request.DoctorId,
                request.StartTime.DayOfWeek);

        if (workingHour is null)
            throw new Exception("Doctor does not work on the selected day.");

        var appointmentStartTime = TimeOnly.FromDateTime(request.StartTime);
        var appointmentEndTime = appointmentStartTime.AddMinutes(appointmentDuration);

        if (appointmentStartTime < workingHour.StartTime ||
            appointmentEndTime > workingHour.EndTime)
        {
            throw new Exception(
                "Appointment time is outside the doctor's working hours.");
        }

        var isDoctorOnLeave =
            await _doctorLeaveRepository.IsDoctorOnLeaveAsync(
                request.DoctorId,
                request.StartTime,
                request.StartTime.AddMinutes(appointmentDuration));

        if (isDoctorOnLeave)
            throw new Exception(
                "Doctor is on leave during the selected appointment time.");

        var minutesFromWorkingHourStart =
            (appointmentStartTime - workingHour.StartTime).TotalMinutes;

        if (minutesFromWorkingHourStart % appointmentDuration != 0)
        {
            throw new Exception(
                $"Appointment must start at a valid {appointmentDuration}-minute interval.");
        }

        // Öncelikli kontenjan kontrolü
        if (isPriorityWindow)
        {
            var totalSlots =
                (int)((workingHour.EndTime - workingHour.StartTime)
                    .TotalMinutes / appointmentDuration);

            var priorityLimit = (int)(totalSlots * 0.20);

            if (priorityLimit == 0 && totalSlots > 0)
                priorityLimit = 1;

            var usedPrioritySlots =
                await _appointmentRepository.GetPriorityWindowAppointmentCountAsync(
                    request.DoctorId,
                    appointmentDate,
                    priorityOpenTime,
                    normalOpenTime);

            if (usedPrioritySlots >= priorityLimit)
            {
                throw new Exception(
                    "Öncelikli hasta erken erişim kontenjanı doldu. Normal randevu erişimi saat 00:00'da açılacaktır. Lütfen saat 00:00'dan sonra tekrar deneyiniz.");
            }
        }

        var existingAppointment =
            await _appointmentRepository.GetByDoctorAndStartTimeAsync(
                request.DoctorId,
                request.StartTime);

        if (existingAppointment is not null)
            throw new Exception("The selected appointment time is already booked.");

        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            StartTime = request.StartTime,
            EndTime = request.StartTime.AddMinutes(appointmentDuration),
            CreatedAt = DateTime.Now
        };

        await _appointmentRepository.AddAsync(appointment);

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            PatientId = appointment.PatientId,
            AppointmentId = appointment.Id,
            Message =
                $"Randevunuz {appointment.StartTime:dd.MM.yyyy HH:mm} tarihinde oluşturuldu.",
            IsRead = false
        };

        await _notificationRepository.AddAsync(notification);

        return appointment.Id;
    }
}