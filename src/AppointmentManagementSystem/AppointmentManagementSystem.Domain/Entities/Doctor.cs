using AppointmentManagementSystem.Domain.Common;

namespace AppointmentManagementSystem.Domain.Entities;

public class Doctor : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public Guid BranchId { get; set; }

    public Branch Branch { get; set; } = null!;
}