using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.PatientAppointments;

public class GetPatientPastAppointmentsQuery : IRequest<List<Appointment>>
{
    public Guid PatientId { get; set; }
}