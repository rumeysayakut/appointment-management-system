using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Persistence.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Doctor>> GetByBranchIdAsync(Guid branchId)
    {
        return await _context.Doctors
            .Where(x => x.BranchId == branchId)
            .ToListAsync();
    }

    public async Task<bool> IsDoctorOnLeaveAsync(
    Guid doctorId,
    DateTime startDate,
    DateTime endDate)
    {
        return await _context.DoctorLeaves
            .AnyAsync(x =>
                x.DoctorId == doctorId &&
                x.StartDate <= endDate &&
                x.EndDate >= startDate);
    }
    public async Task DeleteAsync(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Doctor>> GetAllAsync()
    {
        return await _context.Doctors
            .Include(x => x.Branch)
            .AsNoTracking()
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await _context.Doctors
            .Include(x => x.Branch)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }
}