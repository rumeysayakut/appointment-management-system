namespace AppointmentManagementSystem.Application.Features.Notifications.DTOs;

public class NotificationDto
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Guid AppointmentId { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; }
}