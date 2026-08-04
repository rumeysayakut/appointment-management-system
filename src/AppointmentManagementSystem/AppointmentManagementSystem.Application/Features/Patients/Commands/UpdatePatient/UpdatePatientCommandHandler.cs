using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler
    : IRequestHandler<UpdatePatientCommand, Guid>
{
    private readonly IPatientRepository _patientRepository;

    public UpdatePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Guid> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.Id);

        if (patient is null)
            throw new Exception("Patient not found.");

        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.IdentityNumber = request.IdentityNumber;
        patient.Phone = request.Phone;
        patient.BirthDate = request.BirthDate;

        await _patientRepository.UpdateAsync(patient);

        return patient.Id;
    }
}