namespace AppointmentManagementSystem.Domain.Enums;

public enum AppointmentStatus
{
    Scheduled,
    Completed,
    CancelledByPatient,
    CancelledByDoctor,
    NoShow
}