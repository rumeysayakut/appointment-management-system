using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetPatientAppointmentHistory;

public class GetPatientAppointmentHistoryQueryHandler
    : IRequestHandler<
        GetPatientAppointmentHistoryQuery,
        List<PatientAppointmentHistoryDto>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public GetPatientAppointmentHistoryQueryHandler(
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository)
    {
        _patientRepository = patientRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<PatientAppointmentHistoryDto>> Handle(
        GetPatientAppointmentHistoryQuery request,
        CancellationToken cancellationToken)
    {
        var patient =
            await _patientRepository
                .GetByIdentityNumberAsync(request.IdentityNumber);

        if (patient is null)
            throw new Exception("Hasta bulunamadı.");

        var appointments =
            await _appointmentRepository
                .GetByPatientIdAsync(patient.Id);

        return appointments
            .Where(x => x.StartTime < DateTime.Now)
            .OrderByDescending(x => x.StartTime)
            .Select(x => new PatientAppointmentHistoryDto
            {
                AppointmentId = x.Id,
                DoctorName =
                    $"{x.Doctor.FirstName} {x.Doctor.LastName}",
                BranchName =
                    x.Doctor.Branch?.Name ?? "-",
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = x.Status.ToString()
            })
            .ToList();
    }
}