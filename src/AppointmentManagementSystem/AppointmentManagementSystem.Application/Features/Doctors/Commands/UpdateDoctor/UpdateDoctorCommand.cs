using MediatR;

namespace AppointmentManagementSystem.Application.Features.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public Guid BranchId { get; set; }
}