using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommand : IRequest<Guid>
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public bool HasPriorityRequest { get; set; }
    public DateTime StartTime { get; set; }
}