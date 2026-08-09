using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.CreateDoctorLeave;

public class CreateDoctorLeaveCommand : IRequest<Guid>
{
    public Guid DoctorId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}