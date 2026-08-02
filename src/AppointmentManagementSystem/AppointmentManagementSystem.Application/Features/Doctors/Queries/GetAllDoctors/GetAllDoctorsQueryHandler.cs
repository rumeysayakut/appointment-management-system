using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorListDto>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<DoctorListDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _doctorRepository.GetAllAsync();

        return doctors.Select(x => new DoctorListDto
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Phone = x.Phone,
            BranchId = x.BranchId,
            BranchName = x.Branch.Name
        }).ToList();
    }
}