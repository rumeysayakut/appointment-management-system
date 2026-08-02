using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.DeleteDoctorWorkingHour;

public class DeleteDoctorWorkingHourCommandHandler
    : IRequestHandler<DeleteDoctorWorkingHourCommand>
{
    private readonly IDoctorWorkingHourRepository _workingHourRepository;

    public DeleteDoctorWorkingHourCommandHandler(
        IDoctorWorkingHourRepository workingHourRepository)
    {
        _workingHourRepository = workingHourRepository;
    }

    public async Task<Unit> Handle(
        DeleteDoctorWorkingHourCommand request,
        CancellationToken cancellationToken)
    {
        var workingHour = await _workingHourRepository.GetByIdAsync(request.Id);

        if (workingHour is null)
            throw new Exception("Working hour not found.");

        await _workingHourRepository.DeleteAsync(workingHour);

        return Unit.Value;
    }
}