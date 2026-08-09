using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Enums;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CancelAppointment;

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, Unit>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CancelAppointmentCommandHandler(
        IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Unit> Handle(
        CancelAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment is null)
            throw new Exception("Appointment not found.");

        if (appointment.Status == AppointmentStatus.Completed)
            throw new Exception("Completed appointment cannot be cancelled.");

        if (appointment.Status == AppointmentStatus.NoShow)
            throw new Exception("No-show appointment cannot be cancelled.");

        if (appointment.Status == AppointmentStatus.CancelledByPatient ||
            appointment.Status == AppointmentStatus.CancelledByDoctor)
            throw new Exception("Appointment is already cancelled.");

        var cancellationLimit = appointment.StartTime.AddHours(-2);

        if (DateTime.Now > cancellationLimit)
            throw new Exception("Appointment can only be cancelled at least 2 hours in advance.");

        appointment.Status = AppointmentStatus.CancelledByPatient;

        await _appointmentRepository.UpdateAsync(appointment);

        return Unit.Value;
    }
}