using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Enums;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.CompleteAppointment;

public class CompleteAppointmentCommandHandler : IRequestHandler<CompleteAppointmentCommand, Unit>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CompleteAppointmentCommandHandler(
        IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Unit> Handle(
        CompleteAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment is null)
            throw new Exception("Appointment not found.");

        if (appointment.Status == AppointmentStatus.Completed)
            throw new Exception("Appointment is already completed.");

        if (appointment.Status == AppointmentStatus.CancelledByPatient ||
            appointment.Status == AppointmentStatus.CancelledByDoctor)
            throw new Exception("Cancelled appointment cannot be completed.");

        if (appointment.Status == AppointmentStatus.NoShow)
            throw new Exception("No-show appointment cannot be completed.");

        appointment.Status = AppointmentStatus.Completed;

        await _appointmentRepository.UpdateAsync(appointment);

        return Unit.Value;
    }
}