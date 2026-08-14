using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.PatientAppointments;

public class GetPatientPastAppointmentsQueryHandler
    : IRequestHandler<GetPatientPastAppointmentsQuery, List<Appointment>>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetPatientPastAppointmentsQueryHandler(
        IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<Appointment>> Handle(
        GetPatientPastAppointmentsQuery request,
        CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository
            .GetByPatientIdAsync(request.PatientId);

        return appointments
            .Where(x => x.StartTime < DateTime.Now)
            .OrderByDescending(x => x.StartTime)
            .ToList();
    }
}