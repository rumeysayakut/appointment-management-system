using AppointmentManagementSystem.Domain.Common;

namespace AppointmentManagementSystem.Domain.Entities;

public class DoctorLeave : BaseEntity
{
    public Guid DoctorId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Doctor Doctor { get; set; } = null!;
}