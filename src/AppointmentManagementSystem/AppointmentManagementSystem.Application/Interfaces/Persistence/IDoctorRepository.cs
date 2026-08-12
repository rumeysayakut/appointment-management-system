using AppointmentManagementSystem.Domain.Entities;

namespace AppointmentManagementSystem.Application.Interfaces.Persistence;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllAsync();

    Task<Doctor?> GetByIdAsync(Guid id);

    Task<List<Doctor>> GetByBranchIdAsync(Guid branchId);

    Task AddAsync(Doctor doctor);

    Task UpdateAsync(Doctor doctor);

    Task DeleteAsync(Doctor doctor);
}