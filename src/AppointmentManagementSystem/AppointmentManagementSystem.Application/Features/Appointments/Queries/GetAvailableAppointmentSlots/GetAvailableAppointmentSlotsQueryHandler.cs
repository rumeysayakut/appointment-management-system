using AppointmentManagementSystem.Application.Common.Settings;
using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.Extensions.Options;

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
    private readonly AppointmentSettings _appointmentSettings;

    public GetAvailableAppointmentSlotsQueryHandler(
        IAppointmentRepository appointmentRepository,
        IDoctorRepository doctorRepository,
        IDoctorWorkingHourRepository doctorWorkingHourRepository,
        IDoctorLeaveRepository doctorLeaveRepository,
        IOptions<AppointmentSettings> appointmentSettings)
    {
        _appointmentRepository = appointmentRepository;
        _doctorRepository = doctorRepository;
        _doctorWorkingHourRepository = doctorWorkingHourRepository;
        _doctorLeaveRepository = doctorLeaveRepository;
        _appointmentSettings = appointmentSettings.Value;
    }

    public async Task<List<AvailableAppointmentSlotDto>> Handle(
        GetAvailableAppointmentSlotsQuery request,
        CancellationToken cancellationToken)
    {
        var doctors =
            await _doctorRepository.GetByBranchIdAsync(request.BranchId);

        var availableSlots = new List<AvailableAppointmentSlotDto>();

        var dayStart = request.Date.Date;
        var dayEnd = dayStart.AddDays(1);

        foreach (var doctor in doctors)
        {
            var workingHour =
                await _doctorWorkingHourRepository.GetByDoctorAndDayAsync(
                    doctor.Id,
                    request.Date.DayOfWeek);

            if (workingHour is null)
                continue;

            var isOnLeave =
                await _doctorLeaveRepository.IsDoctorOnLeaveAsync(
                    doctor.Id,
                    dayStart,
                    dayEnd);

            if (isOnLeave)
                continue;

            var appointments =
                await _appointmentRepository.GetByDoctorIdAsync(
                    doctor.Id);

            var bookedTimes = appointments
                .Where(x =>
                    x.StartTime >= dayStart &&
                    x.StartTime < dayEnd)
                .Select(x => x.StartTime)
                .ToHashSet();

            var currentTime =
                dayStart.Add(workingHour.StartTime.ToTimeSpan());

            var endTime =
                dayStart.Add(workingHour.EndTime.ToTimeSpan());

            while (currentTime < endTime)
            {
                if (!bookedTimes.Contains(currentTime) &&
                    currentTime > DateTime.Now)
                {
                    availableSlots.Add(
                        new AvailableAppointmentSlotDto
                        {
                            DoctorId = doctor.Id,
                            DoctorName = doctor.FirstName,
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