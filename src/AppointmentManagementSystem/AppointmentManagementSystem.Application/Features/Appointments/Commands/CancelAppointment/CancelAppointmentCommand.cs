using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CancelAppointment;

public class CancelAppointmentCommand : IRequest<Unit>
{
    public Guid AppointmentId { get; set; }
}