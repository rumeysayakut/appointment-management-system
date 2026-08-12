using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Domain.Enums;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.CreateDoctorLeave;

public class CreateDoctorLeaveCommandHandler
    : IRequestHandler<CreateDoctorLeaveCommand, Guid>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorLeaveRepository _doctorLeaveRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;

    public CreateDoctorLeaveCommandHandler(
        IDoctorRepository doctorRepository,
        IDoctorLeaveRepository doctorLeaveRepository,
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository)
    {
        _doctorRepository = doctorRepository;
        _doctorLeaveRepository = doctorLeaveRepository;
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
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
        {
            throw new Exception(
                "Leave start date cannot be after end date.");
        }

        var doctorLeaves = await _doctorLeaveRepository
            .GetByDoctorIdAsync(request.DoctorId);

        var hasOverlap = doctorLeaves.Any(x =>
            request.StartDate.Date <= x.EndDate.Date &&
            request.EndDate.Date >= x.StartDate.Date);

        if (hasOverlap)
        {
            throw new Exception(
                "Doctor already has a leave during the selected dates.");
        }

        var doctorLeave = new DoctorLeave
        {
            Id = Guid.NewGuid(),
            DoctorId = request.DoctorId,
            StartDate = request.StartDate.Date,
            EndDate = request.EndDate.Date
                .AddDays(1)
                .AddTicks(-1)
        };

        await _doctorLeaveRepository.AddAsync(doctorLeave);

        
        var appointments = await _appointmentRepository
            .GetByDoctorIdAsync(request.DoctorId);

        var appointmentsToCancel = appointments
            .Where(x =>
                x.Status == AppointmentStatus.Scheduled &&
                x.StartTime >= doctorLeave.StartDate &&
                x.StartTime <= doctorLeave.EndDate)
            .ToList();

        foreach (var appointment in appointmentsToCancel)
        {
            
            appointment.Status =
                AppointmentStatus.CancelledByDoctor;

            await _appointmentRepository
                .UpdateAsync(appointment);

           
            var patient = await _patientRepository
                .GetByIdAsync(appointment.PatientId);

            if (patient is null)
                continue;

            var normalLastAvailableDate =
                DateTime.Today.AddDays(10);

            var extraAppointmentUntil =
                normalLastAvailableDate.AddDays(5);

           
            if (patient.ExtraAppointmentUntil is null ||
                patient.ExtraAppointmentUntil.Value < extraAppointmentUntil)
            {
                patient.ExtraAppointmentUntil =
                    extraAppointmentUntil;

                await _patientRepository
                    .UpdateAsync(patient);
            }
        }

        return doctorLeave.Id;
    }
}