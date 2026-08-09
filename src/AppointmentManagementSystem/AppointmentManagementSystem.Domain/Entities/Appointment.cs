using AppointmentManagementSystem.Domain.Enums;

namespace AppointmentManagementSystem.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

    public Patient Patient { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
}