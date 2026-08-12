namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetAvailableAppointmentSlots;

public class AvailableAppointmentSlotDto
{
    public Guid DoctorId { get; set; }

    public string DoctorName { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }
}