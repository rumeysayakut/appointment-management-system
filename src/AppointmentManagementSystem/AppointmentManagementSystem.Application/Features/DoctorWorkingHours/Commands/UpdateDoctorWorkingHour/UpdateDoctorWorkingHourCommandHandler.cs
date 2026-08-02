using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.UpdateDoctorWorkingHour;

public class UpdateDoctorWorkingHourCommandHandler
    : IRequestHandler<UpdateDoctorWorkingHourCommand, Guid>
{
    private readonly IDoctorWorkingHourRepository _workingHourRepository;

    public UpdateDoctorWorkingHourCommandHandler(
        IDoctorWorkingHourRepository workingHourRepository)
    {
        _workingHourRepository = workingHourRepository;
    }

    public async Task<Guid> Handle(
        UpdateDoctorWorkingHourCommand request,
        CancellationToken cancellationToken)
    {
        var workingHour = await _workingHourRepository.GetByIdAsync(request.Id);

        if (workingHour is null)
            throw new Exception("Working hour not found.");

        workingHour.DoctorId = request.DoctorId;
        workingHour.DayOfWeek = request.DayOfWeek;
        workingHour.StartTime = request.StartTime;
        workingHour.EndTime = request.EndTime;

        await _workingHourRepository.UpdateAsync(workingHour);

        return workingHour.Id;
    }
}