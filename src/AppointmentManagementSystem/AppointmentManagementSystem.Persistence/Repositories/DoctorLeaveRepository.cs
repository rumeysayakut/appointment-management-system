using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Persistence.Repositories;

public class DoctorLeaveRepository : IDoctorLeaveRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorLeaveRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(DoctorLeave doctorLeave)
    {
        await _context.DoctorLeaves.AddAsync(doctorLeave);
        await _context.SaveChangesAsync();
    }

    public async Task<DoctorLeave?> GetByIdAsync(Guid id)
    {
        return await _context.DoctorLeaves
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(DoctorLeave doctorLeave)
    {
        _context.DoctorLeaves.Update(doctorLeave);
        await _context.SaveChangesAsync();
    }

    public async Task<List<DoctorLeave>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await _context.DoctorLeaves
            .Where(x => x.DoctorId == doctorId)
            .OrderBy(x => x.StartDate)
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

    public async Task DeleteAsync(DoctorLeave doctorLeave)
    {
        _context.DoctorLeaves.Remove(doctorLeave);
        await _context.SaveChangesAsync();
    }
}