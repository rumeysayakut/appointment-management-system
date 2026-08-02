using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Queries.GetAllDoctorWorkingHours;

public class GetAllDoctorWorkingHoursQueryHandler
    : IRequestHandler<GetAllDoctorWorkingHoursQuery, List<DoctorWorkingHourDto>>
{
    private readonly IDoctorWorkingHourRepository _workingHourRepository;

    public GetAllDoctorWorkingHoursQueryHandler(
        IDoctorWorkingHourRepository workingHourRepository)
    {
        _workingHourRepository = workingHourRepository;
    }

    public async Task<List<DoctorWorkingHourDto>> Handle(
        GetAllDoctorWorkingHoursQuery request,
        CancellationToken cancellationToken)
    {
        var workingHours = await _workingHourRepository.GetAllAsync();

        return workingHours.Select(x => new DoctorWorkingHourDto
        {
            Id = x.Id,
            DoctorId = x.DoctorId,
            DoctorName = $"{x.Doctor.FirstName} {x.Doctor.LastName}",
            DayOfWeek = x.DayOfWeek,
            StartTime = x.StartTime,
            EndTime = x.EndTime
        }).ToList();
    }
}