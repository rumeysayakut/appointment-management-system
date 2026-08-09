using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CompleteAppointment;

public class CompleteAppointmentCommand : IRequest<Unit>
{
    public Guid AppointmentId { get; set; }
}