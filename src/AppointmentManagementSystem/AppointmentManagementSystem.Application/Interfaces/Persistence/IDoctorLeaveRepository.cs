using AppointmentManagementSystem.Domain.Entities;

namespace AppointmentManagementSystem.Application.Interfaces.Persistence;

public interface IDoctorLeaveRepository
{
    Task AddAsync(DoctorLeave doctorLeave);

    Task<DoctorLeave?> GetByIdAsync(Guid id);

    Task DeleteAsync(DoctorLeave doctorLeave);

    Task<List<DoctorLeave>> GetByDoctorIdAsync(Guid doctorId);

    Task<bool> IsDoctorOnLeaveAsync(
        Guid doctorId,
        DateTime startDate,
        DateTime endDate);
}