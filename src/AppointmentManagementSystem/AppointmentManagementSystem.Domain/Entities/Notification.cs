namespace AppointmentManagementSystem.Domain.Entities;

public class Notification
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid AppointmentId { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; }

    public Patient Patient { get; set; } = null!;

    public Appointment Appointment { get; set; } = null!;
}