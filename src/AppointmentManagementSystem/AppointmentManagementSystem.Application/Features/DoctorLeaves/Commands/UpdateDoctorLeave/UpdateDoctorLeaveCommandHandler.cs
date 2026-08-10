using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.UpdateDoctorLeave;

public class UpdateDoctorLeaveCommandHandler
    : IRequestHandler<UpdateDoctorLeaveCommand, Unit>
{
    private readonly IDoctorLeaveRepository _doctorLeaveRepository;

    public UpdateDoctorLeaveCommandHandler(
        IDoctorLeaveRepository doctorLeaveRepository)
    {
        _doctorLeaveRepository = doctorLeaveRepository;
    }

    public async Task<Unit> Handle(
        UpdateDoctorLeaveCommand request,
        CancellationToken cancellationToken)
    {
        var doctorLeave = await _doctorLeaveRepository
            .GetByIdAsync(request.Id);

        if (doctorLeave is null)
            throw new Exception("Doctor leave not found.");

        if (request.StartDate.Date > request.EndDate.Date)
            throw new Exception(
                "Leave start date cannot be after end date.");

        var doctorLeaves = await _doctorLeaveRepository
            .GetByDoctorIdAsync(doctorLeave.DoctorId);

        var hasOverlap = doctorLeaves.Any(x =>
            x.Id != request.Id &&
            request.StartDate.Date <= x.EndDate.Date &&
            request.EndDate.Date >= x.StartDate.Date);

        if (hasOverlap)
            throw new Exception(
                "Doctor already has a leave during the selected dates.");

        doctorLeave.StartDate = request.StartDate.Date;
        doctorLeave.EndDate = request.EndDate.Date
            .AddDays(1)
            .AddTicks(-1);

        await _doctorLeaveRepository.UpdateAsync(doctorLeave);

        return Unit.Value;
    }
}