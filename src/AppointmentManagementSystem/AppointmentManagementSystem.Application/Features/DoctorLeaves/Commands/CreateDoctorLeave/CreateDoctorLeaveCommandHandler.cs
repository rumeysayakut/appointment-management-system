using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.CreateDoctorLeave;

public class CreateDoctorLeaveCommandHandler
    : IRequestHandler<CreateDoctorLeaveCommand, Guid>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorLeaveRepository _doctorLeaveRepository;

    public CreateDoctorLeaveCommandHandler(
        IDoctorRepository doctorRepository,
        IDoctorLeaveRepository doctorLeaveRepository)
    {
        _doctorRepository = doctorRepository;
        _doctorLeaveRepository = doctorLeaveRepository;
    }

    public async Task<Guid> Handle(
        CreateDoctorLeaveCommand request,
        CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository
            .GetByIdAsync(request.DoctorId);

        if (doctor is null)
            throw new Exception("Doctor not found.");

        if (request.StartDate.Date > request.EndDate.Date)
            throw new Exception(
                "Leave start date cannot be after end date.");

        var doctorLeaves = await _doctorLeaveRepository
            .GetByDoctorIdAsync(request.DoctorId);

        var hasOverlap = doctorLeaves.Any(x =>
            request.StartDate.Date <= x.EndDate.Date &&
            request.EndDate.Date >= x.StartDate.Date);

        if (hasOverlap)
            throw new Exception(
                "Doctor already has a leave during the selected dates.");

        var doctorLeave = new DoctorLeave
        {
            Id = Guid.NewGuid(),
            DoctorId = request.DoctorId,
            StartDate = request.StartDate.Date,
            EndDate = request.EndDate.Date.AddDays(1).AddTicks(-1)
        };

        await _doctorLeaveRepository.AddAsync(doctorLeave);

        return doctorLeave.Id;
    }
}