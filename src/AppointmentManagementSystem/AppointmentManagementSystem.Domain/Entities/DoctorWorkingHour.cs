using AppointmentManagementSystem.Domain.Common;

namespace AppointmentManagementSystem.Domain.Entities;

public class DoctorWorkingHour : BaseEntity
{
    public Guid DoctorId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public Doctor Doctor { get; set; } = null!;
}