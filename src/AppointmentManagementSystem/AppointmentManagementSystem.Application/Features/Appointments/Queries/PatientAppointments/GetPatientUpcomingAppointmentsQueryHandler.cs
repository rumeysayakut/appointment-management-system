using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.PatientAppointments;

public class GetPatientUpcomingAppointmentsQueryHandler
    : IRequestHandler<GetPatientUpcomingAppointmentsQuery, List<Appointment>>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetPatientUpcomingAppointmentsQueryHandler(
        IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<Appointment>> Handle(
        GetPatientUpcomingAppointmentsQuery request,
        CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository
            .GetByPatientIdAsync(request.PatientId);

        return appointments
            .Where(x => x.StartTime >= DateTime.Now)
            .OrderBy(x => x.StartTime)
            .ToList();
    }
}