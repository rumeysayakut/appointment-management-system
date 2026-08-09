using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Enums;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Commands.MarkAppointmentAsNoShow;

public class MarkAppointmentAsNoShowCommandHandler : IRequestHandler<MarkAppointmentAsNoShowCommand, Unit>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public MarkAppointmentAsNoShowCommandHandler(
        IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Unit> Handle(
        MarkAppointmentAsNoShowCommand request,
        CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

        if (appointment is null)
            throw new Exception("Appointment not found.");

        if (appointment.Status == AppointmentStatus.Completed)
            throw new Exception("Completed appointment cannot be marked as no-show.");

        if (appointment.Status == AppointmentStatus.CancelledByPatient ||
            appointment.Status == AppointmentStatus.CancelledByDoctor)
            throw new Exception("Cancelled appointment cannot be marked as no-show.");

        if (appointment.Status == AppointmentStatus.NoShow)
            throw new Exception("Appointment is already marked as no-show.");

        appointment.Status = AppointmentStatus.NoShow;

        await _appointmentRepository.UpdateAsync(appointment);

        return Unit.Value;
    }
}