using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.PatientAppointments;

public class GetPatientAppointmentsQuery : IRequest<List<Appointment>>
{
    public Guid PatientId { get; set; }
}