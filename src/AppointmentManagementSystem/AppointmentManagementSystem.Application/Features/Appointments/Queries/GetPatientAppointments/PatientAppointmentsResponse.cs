namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetPatientAppointments;

public class PatientAppointmentsResponse
{
    public List<PatientAppointmentDto> UpcomingAppointments { get; set; }
        = new();

    public List<PatientAppointmentDto> PastAppointments { get; set; }
        = new();
}

public class PatientAppointmentDto
{
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    public string DoctorName { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Status { get; set; } = string.Empty;
}