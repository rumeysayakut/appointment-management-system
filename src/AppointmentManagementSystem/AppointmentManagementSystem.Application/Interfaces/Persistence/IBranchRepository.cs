using AppointmentManagementSystem.Domain.Entities;

namespace AppointmentManagementSystem.Application.Interfaces.Persistence;

public interface IBranchRepository
{
    Task<List<Branch>> GetAllAsync();

    Task<Branch?> GetByIdAsync(Guid id);

    Task<Branch?> GetByNameAsync(string name);

    Task AddAsync(Branch branch);

    Task UpdateAsync(Branch branch);

    Task DeleteAsync(Branch branch);
}