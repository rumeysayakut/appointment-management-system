using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.DoctorAppointments;

public class GetDoctorAppointmentsQuery : IRequest<List<Appointment>>
{
    public Guid DoctorId { get; set; }
}