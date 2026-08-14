using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetPatientAppointments;

public class GetPatientAppointmentsQuery : IRequest<PatientAppointmentsResponse>
{
    public Guid PatientId { get; set; }
}