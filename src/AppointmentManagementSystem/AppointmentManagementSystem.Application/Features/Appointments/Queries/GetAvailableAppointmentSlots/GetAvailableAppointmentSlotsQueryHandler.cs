using AppointmentManagementSystem.Application.Common.Settings;
using AppointmentManagementSystem.Application.Interfaces.ExternalServices;
using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.Extensions.Options;
using AppointmentManagementSystem.Domain.Enums;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetAvailableAppointmentSlots;

public class GetAvailableAppointmentSlotsQueryHandler
    : IRequestHandler<
        GetAvailableAppointmentSlotsQuery,
        List<AvailableAppointmentSlotDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorWorkingHourRepository _doctorWorkingHourRepository;
    private readonly IDoctorLeaveRepository _doctorLeaveRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IPatientPriorityService _patientPriorityService;
    private readonly AppointmentSettings _appointmentSettings;

    public GetAvailableAppointmentSlotsQueryHandler(
        IAppointmentRepository appointmentRepository,
        IDoctorRepository doctorRepository,
        IDoctorWorkingHourRepository doctorWorkingHourRepository,
        IDoctorLeaveRepository doctorLeaveRepository,
        IPatientRepository patientRepository,
        IPatientPriorityService patientPriorityService,
        IOptions<AppointmentSettings> appointmentSettings)
    {
        _appointmentRepository = appointmentRepository;
        _doctorRepository = doctorRepository;
        _doctorWorkingHourRepository = doctorWorkingHourRepository;
        _doctorLeaveRepository = doctorLeaveRepository;
        _patientRepository = patientRepository;
        _patientPriorityService = patientPriorityService;
        _appointmentSettings = appointmentSettings.Value;
    }

    public async Task<List<AvailableAppointmentSlotDto>> Handle(
        GetAvailableAppointmentSlotsQuery request,
        CancellationToken cancellationToken)
    {
        var patient =
            await _patientRepository.GetByIdAsync(request.PatientId);

        if (patient is null)
            throw new Exception("Patient not found.");

        var isPriorityPatient = false;

        if (request.HasPriorityRequest)
        {
            isPriorityPatient =
                await _patientPriorityService
                    .IsPriorityPatientAsync(patient.IdentityNumber);
        }

        var availableSlots = new List<AvailableAppointmentSlotDto>();

        var dayStart = request.Date.Date;
        var dayEnd = dayStart.AddDays(1);

        var now = DateTime.Now;

        // Normal erişim: Randevu tarihinden 10 gün önce saat 00:00
        var normalOpenTime = dayStart.AddDays(-10);

        // Öncelikli erişim: 6 saat önce
        var priorityOpenTime = normalOpenTime.AddHours(-6);

        // Henüz öncelikli erişim bile başlamadıysa kimse slot göremez.
        if (now < priorityOpenTime)
            return availableSlots;

        // Erken erişim dönemindeysek normal hasta göremez.
        var isPriorityWindow =
            now >= priorityOpenTime &&
            now < normalOpenTime;

        if (isPriorityWindow && !isPriorityPatient)
            return availableSlots;

        var doctors =
            await _doctorRepository.GetByBranchIdAsync(request.BranchId);

        foreach (var doctor in doctors)
        {
            var workingHour =
                await _doctorWorkingHourRepository
                    .GetByDoctorAndDayAsync(
                        doctor.Id,
                        request.Date.DayOfWeek);

            if (workingHour is null)
                continue;

            var isOnLeave =
                await _doctorLeaveRepository
                    .IsDoctorOnLeaveAsync(
                        doctor.Id,
                        dayStart,
                        dayEnd);

            if (isOnLeave)
                continue;

            var appointments =
                await _appointmentRepository
                    .GetByDoctorIdAsync(doctor.Id);

            var bookedTimes = appointments
      .Where(x =>
          x.StartTime >= dayStart &&
          x.StartTime < dayEnd &&
          x.Status != AppointmentStatus.CancelledByPatient &&
          x.Status != AppointmentStatus.CancelledByDoctor)
      .Select(x => x.StartTime)
      .ToHashSet();

            var currentTime =
                dayStart.Add(workingHour.StartTime.ToTimeSpan());

            var endTime =
                dayStart.Add(workingHour.EndTime.ToTimeSpan());

            while (currentTime < endTime)
            {
                if (!bookedTimes.Contains(currentTime) &&
                    currentTime > now)
                {
                    availableSlots.Add(
                        new AvailableAppointmentSlotDto
                        {
                            DoctorId = doctor.Id,
                            DoctorName =
                                $"{doctor.FirstName} {doctor.LastName}",
                            StartTime = currentTime
                        });
                }

                currentTime = currentTime.AddMinutes(
                    _appointmentSettings.DurationInMinutes);
            }
        }

        return availableSlots
            .OrderBy(x => x.StartTime)
            .ThenBy(x => x.DoctorName)
            .ToList();
    }
}