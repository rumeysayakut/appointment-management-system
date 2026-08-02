using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Guid>
{
    private readonly IDoctorRepository _doctorRepository;

    public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Guid> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.Id);

        if (doctor is null)
            throw new Exception("Doctor not found.");

        doctor.FirstName = request.FirstName;
        doctor.LastName = request.LastName;
        doctor.Email = request.Email;
        doctor.Phone = request.Phone;
        doctor.BranchId = request.BranchId;

        await _doctorRepository.UpdateAsync(doctor);

        return doctor.Id;
    }
}