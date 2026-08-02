using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.CreateDoctorWorkingHour;

public class CreateDoctorWorkingHourCommand : IRequest<Guid>
{
    public Guid DoctorId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}