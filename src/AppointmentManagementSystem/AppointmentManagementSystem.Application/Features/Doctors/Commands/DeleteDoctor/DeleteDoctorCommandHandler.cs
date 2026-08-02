using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Doctors.Commands.DeleteDoctor;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IDoctorRepository _doctorRepository;

    public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.Id);

        if (doctor is null)
            throw new Exception("Doctor not found.");

        await _doctorRepository.DeleteAsync(doctor);

        return Unit.Value;
    }
}