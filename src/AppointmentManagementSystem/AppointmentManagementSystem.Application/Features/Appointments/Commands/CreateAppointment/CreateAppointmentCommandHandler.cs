using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorWorkingHourRepository _doctorWorkingHourRepository;
    private readonly IDoctorLeaveRepository _doctorLeaveRepository;
    private readonly INotificationRepository _notificationRepository;

    public CreateAppointmentCommandHandler(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IDoctorWorkingHourRepository doctorWorkingHourRepository,
        IDoctorLeaveRepository doctorLeaveRepository,
        INotificationRepository notificationRepository)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _doctorWorkingHourRepository = doctorWorkingHourRepository;
        _doctorLeaveRepository = doctorLeaveRepository;
        _notificationRepository = notificationRepository;
    }

    public async Task<Guid> Handle(
        CreateAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.PatientId);

        if (patient is null)
            throw new Exception("Patient not found.");

        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        if (doctor is null)
            throw new Exception("Doctor not found.");

        var appointmentDate = request.StartTime.Date;
        var today = DateTime.Today;
        var lastAvailableDate = today.AddDays(10);

        if (appointmentDate < today)
            throw new Exception("Appointment cannot be created for a past date.");

        if (appointmentDate > lastAvailableDate)
            throw new Exception("Appointment can only be created up to 10 days in advance.");

        var dayOfWeek = request.StartTime.DayOfWeek;

        var workingHour = await _doctorWorkingHourRepository
            .GetByDoctorAndDayAsync(request.DoctorId, dayOfWeek);

        if (workingHour is null)
            throw new Exception("Doctor does not work on the selected day.");

        var appointmentStartTime = TimeOnly.FromDateTime(request.StartTime);
        var appointmentEndTime = appointmentStartTime.AddMinutes(30);

        if (appointmentStartTime < workingHour.StartTime ||
            appointmentEndTime > workingHour.EndTime)
        {
            throw new Exception("Appointment time is outside the doctor's working hours.");
        }
        var appointmentStartDateTime = request.StartTime;
        var appointmentEndDateTime = request.StartTime.AddMinutes(30);

        var isDoctorOnLeave = await _doctorLeaveRepository
            .IsDoctorOnLeaveAsync(
                request.DoctorId,
                appointmentStartDateTime,
                appointmentEndDateTime);

        if (isDoctorOnLeave)
        {
            throw new Exception(
                "Doctor is on leave during the selected appointment time.");
        }
        if (appointmentStartTime.Minute != 0 &&
            appointmentStartTime.Minute != 30)
        {
            throw new Exception("Appointment must start at a 30-minute interval.");
        }

        var existingAppointment = await _appointmentRepository
            .GetByDoctorAndStartTimeAsync(
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
            EndTime = request.StartTime.AddMinutes(30)
        };

        await _appointmentRepository.AddAsync(appointment);

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            PatientId = appointment.PatientId,
            AppointmentId = appointment.Id,
            Message = $"Randevunuz {appointment.StartTime:dd.MM.yyyy HH:mm} tarihinde oluşturuldu.",
            IsRead = false
        };

        await _notificationRepository.AddAsync(notification);

        return appointment.Id;
    }
}