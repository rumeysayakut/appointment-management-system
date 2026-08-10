using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.UpdateDoctorLeave;

public class UpdateDoctorLeaveCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}