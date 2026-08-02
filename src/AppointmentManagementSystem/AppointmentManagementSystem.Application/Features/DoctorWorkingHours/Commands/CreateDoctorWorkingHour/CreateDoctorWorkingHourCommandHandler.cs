using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.CreateDoctorWorkingHour;

public class CreateDoctorWorkingHourCommandHandler : IRequestHandler<CreateDoctorWorkingHourCommand, Guid>
{
    private readonly IDoctorWorkingHourRepository _workingHourRepository;

    public CreateDoctorWorkingHourCommandHandler(IDoctorWorkingHourRepository workingHourRepository)
    {
        _workingHourRepository = workingHourRepository;
    }

    public async Task<Guid> Handle(CreateDoctorWorkingHourCommand request, CancellationToken cancellationToken)
    {
        var workingHour = new DoctorWorkingHour
        {
            DoctorId = request.DoctorId,
            DayOfWeek = request.DayOfWeek,
            StartTime = request.StartTime,
            EndTime = request.EndTime
        };

        await _workingHourRepository.AddAsync(workingHour);

        return workingHour.Id;
    }
}