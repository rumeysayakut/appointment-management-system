using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.MarkAppointmentAsNoShow;

public class MarkAppointmentAsNoShowCommand : IRequest<Unit>
{
    public Guid AppointmentId { get; set; }
}