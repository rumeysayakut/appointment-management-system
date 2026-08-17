using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Persistence.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Patient patient)
    {
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        return await _context.Patients
            .AsNoTracking()
            .OrderBy(x => x.FirstName)
            .ToListAsync();
    }

    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await _context.Patients
            .FirstOrDefaultAsync(x => x.Id == id);
    }

   
    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<Patient?> GetByIdentityNumberAsync(
    string identityNumber)
    {
        return await _context.Patients
            .FirstOrDefaultAsync(x =>
                x.IdentityNumber == identityNumber);
    }
}