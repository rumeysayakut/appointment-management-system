using MediatR;

namespace AppointmentManagementSystem.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string IdentityNumber { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }
}