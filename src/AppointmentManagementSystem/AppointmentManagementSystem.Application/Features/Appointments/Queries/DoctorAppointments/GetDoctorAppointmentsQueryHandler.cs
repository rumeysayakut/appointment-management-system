using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.DoctorAppointments;

public class GetDoctorAppointmentsQueryHandler
    : IRequestHandler<GetDoctorAppointmentsQuery, List<Appointment>>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetDoctorAppointmentsQueryHandler(
        IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<Appointment>> Handle(
        GetDoctorAppointmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await _appointmentRepository
            .GetByDoctorIdAsync(request.DoctorId);
    }
}