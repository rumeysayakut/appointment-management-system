using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetPatientAppointments;

public class GetPatientAppointmentsQueryHandler
    : IRequestHandler<GetPatientAppointmentsQuery, PatientAppointmentsResponse>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public GetPatientAppointmentsQueryHandler(
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository)
    {
        _patientRepository = patientRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<PatientAppointmentsResponse> Handle(
        GetPatientAppointmentsQuery request,
        CancellationToken cancellationToken)
    {
        var patient = await _patientRepository
            .GetByIdAsync(request.PatientId);

        if (patient is null)
            throw new Exception("Patient not found.");

        var appointments = await _appointmentRepository
            .GetByPatientIdAsync(request.PatientId);

        var now = DateTime.Now;

        var response = new PatientAppointmentsResponse();

        response.UpcomingAppointments = appointments
            .Where(x => x.StartTime >= now)
            .OrderBy(x => x.StartTime)
            .Select(x => new PatientAppointmentDto
            {
                Id = x.Id,
                DoctorId = x.DoctorId,
                DoctorName =
                    $"{x.Doctor.FirstName} {x.Doctor.LastName}",
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status.ToString()
            })
            .ToList();

        response.PastAppointments = appointments
            .Where(x => x.StartTime < now)
            .OrderByDescending(x => x.StartTime)
            .Select(x => new PatientAppointmentDto
            {
                Id = x.Id,
                DoctorId = x.DoctorId,
                DoctorName =
                    $"{x.Doctor.FirstName} {x.Doctor.LastName}",
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status.ToString()
            })
            .ToList();

        return response;
    }
}