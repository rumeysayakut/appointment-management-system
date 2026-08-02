using MediatR;

namespace AppointmentManagementSystem.Application.Features.Doctors.Commands.DeleteDoctor;

public class DeleteDoctorCommand : IRequest
{
    public Guid Id { get; set; }
}