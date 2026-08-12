using AppointmentManagementSystem.Domain.Entities;

namespace AppointmentManagementSystem.Application.Interfaces.Persistence;

public interface IAppointmentRepository
{
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task<Appointment?> GetByIdAsync(Guid id);
    Task<List<Appointment>> GetByDoctorIdAsync(Guid doctorId);
    Task< List<Appointment>> GetByPatientIdAsync(Guid patientId);
    Task<Appointment?> GetByDoctorAndStartTimeAsync(
        Guid doctorId,
        DateTime startTime);
}