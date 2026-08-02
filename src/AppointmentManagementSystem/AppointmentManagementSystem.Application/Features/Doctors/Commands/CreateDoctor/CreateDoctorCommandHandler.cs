using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Doctors.Commands.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Guid>
{
    private readonly IDoctorRepository _doctorRepository;

    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            BranchId = request.BranchId
        };

        await _doctorRepository.AddAsync(doctor);

        return doctor.Id;
    }
}