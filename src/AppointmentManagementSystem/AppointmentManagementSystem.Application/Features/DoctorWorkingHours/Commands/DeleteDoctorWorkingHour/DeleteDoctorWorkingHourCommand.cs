using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.DeleteDoctorWorkingHour;

public class DeleteDoctorWorkingHourCommand : IRequest
{
    public Guid Id { get; set; }
}