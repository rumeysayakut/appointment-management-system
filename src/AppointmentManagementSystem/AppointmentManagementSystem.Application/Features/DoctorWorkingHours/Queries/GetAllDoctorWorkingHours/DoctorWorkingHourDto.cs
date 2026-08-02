namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Queries.GetAllDoctorWorkingHours;

public class DoctorWorkingHourDto
{
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    public string DoctorName { get; set; } = string.Empty;

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}