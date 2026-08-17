using AppointmentManagementSystem.Domain.Entities;

namespace AppointmentManagementSystem.Application.Interfaces.Persistence;

public interface IPatientRepository
{
    Task AddAsync(Patient patient);

    Task UpdateAsync(Patient patient);

    Task DeleteAsync(Patient patient);

    Task<Patient?> GetByIdAsync(Guid id);
    Task<List<Patient>> GetAllAsync();

    Task<Patient?> GetByIdentityNumberAsync(string identityNumber);
}