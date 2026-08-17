namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetPatientAppointmentHistory;

public class PatientAppointmentHistoryDto
{
    public Guid AppointmentId { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
}