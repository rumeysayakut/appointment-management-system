namespace AppointmentManagementSystem.Application.Features.Appointments.DTOs;

public class CreateAppointmentDto
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime StartTime { get; set; }
}