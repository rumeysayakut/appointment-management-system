using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.PatientAppointments;

public class GetPatientAppointmentsQueryHandler
    : IRequestHandler<GetPatientAppointmentsQuery, List<Appointment>>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetPatientAppointmentsQueryHandler(
        IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<Appointment>> Handle(
        GetPatientAppointmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await _appointmentRepository
            .GetByPatientIdAsync(request.PatientId);
    }
}