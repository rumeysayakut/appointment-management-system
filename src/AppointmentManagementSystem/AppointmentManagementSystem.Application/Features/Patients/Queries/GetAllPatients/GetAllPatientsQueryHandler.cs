using AppointmentManagementSystem.Application.Features.Patients.DTOs;
using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Patients.Queries.GetAllPatients;

public class GetAllPatientsQueryHandler
    : IRequestHandler<GetAllPatientsQuery, List<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;

    public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<List<PatientDto>> Handle(
        GetAllPatientsQuery request,
        CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetAllAsync();

        return patients.Select(x => new PatientDto
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            IdentityNumber = x.IdentityNumber,
            Phone = x.Phone,
            BirthDate = x.BirthDate
        }).ToList();
    }
}