using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IDoctorWorkingHourRepository _doctorWorkingHourRepository;

    public CreateAppointmentCommandHandler(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IDoctorWorkingHourRepository doctorWorkingHourRepository)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _doctorWorkingHourRepository = doctorWorkingHourRepository;
    }

    public async Task<Guid> Handle(
        CreateAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.PatientId);

        if (patient is null)
            throw new Exception("Patient not found.");

        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        if (doctor is null)
            throw new Exception("Doctor not found.");

        var appointmentDate = request.StartTime.Date;
        var today = DateTime.Today;
        var lastAvailableDate = today.AddDays(10);

        if (appointmentDate < today)
            throw new Exception("Appointment cannot be created for a past date.");

        if (appointmentDate > lastAvailableDate)
            throw new Exception("Appointment can only be created up to 10 days in advance.");

        var dayOfWeek = request.StartTime.DayOfWeek;

        var workingHour = await _doctorWorkingHourRepository
            .GetByDoctorAndDayAsync(request.DoctorId, dayOfWeek);

        if (workingHour is null)
            throw new Exception("Doctor does not work on the selected day.");

        var appointmentStartTime = TimeOnly.FromDateTime(request.StartTime);
        var appointmentEndTime = appointmentStartTime.AddMinutes(30);

        if (appointmentStartTime < workingHour.StartTime ||
            appointmentEndTime > workingHour.EndTime)
        {
            throw new Exception("Appointment time is outside the doctor's working hours.");
        }

        if (appointmentStartTime.Minute != 0 &&
            appointmentStartTime.Minute != 30)
        {
            throw new Exception("Appointment must start at a 30-minute interval.");
        }

        var existingAppointment = await _appointmentRepository
            .GetByDoctorAndStartTimeAsync(
                request.DoctorId,
                request.StartTime);

        if (existingAppointment is not null)
            throw new Exception("The selected appointment time is already booked.");

        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            StartTime = request.StartTime,
            EndTime = request.StartTime.AddMinutes(30)
        };

        await _appointmentRepository.AddAsync(appointment);

        return appointment.Id;
    }
}