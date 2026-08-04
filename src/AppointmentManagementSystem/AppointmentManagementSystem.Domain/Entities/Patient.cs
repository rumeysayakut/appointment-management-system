using AppointmentManagementSystem.Domain.Common;

namespace AppointmentManagementSystem.Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string IdentityNumber { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }
}