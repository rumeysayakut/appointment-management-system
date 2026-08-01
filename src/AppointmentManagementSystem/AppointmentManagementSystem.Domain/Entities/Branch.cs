using AppointmentManagementSystem.Domain.Common;

namespace AppointmentManagementSystem.Domain.Entities;

public class Branch : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}