using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.UpdateDoctorWorkingHour;

public class UpdateDoctorWorkingHourCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}