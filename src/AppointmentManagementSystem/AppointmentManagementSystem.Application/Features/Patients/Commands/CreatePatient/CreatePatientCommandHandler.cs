using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly IPatientRepository _patientRepository;

    public CreatePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var existingPatient = await _patientRepository.GetByIdentityNumberAsync(request.IdentityNumber);

        if (existingPatient is not null)
            throw new Exception("A patient with this identity number already exists.");

        var patient = new Patient
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            IdentityNumber = request.IdentityNumber,
            Phone = request.Phone,
            BirthDate = request.BirthDate
        };

        await _patientRepository.AddAsync(patient);

        return patient.Id;
    }
}