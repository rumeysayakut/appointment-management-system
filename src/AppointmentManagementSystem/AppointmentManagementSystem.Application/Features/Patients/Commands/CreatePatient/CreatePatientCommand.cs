using MediatR;

namespace AppointmentManagementSystem.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommand : IRequest<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string IdentityNumber { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }
}