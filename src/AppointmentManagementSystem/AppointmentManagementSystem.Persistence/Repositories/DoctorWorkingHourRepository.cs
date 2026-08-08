using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Persistence.Repositories;

public class DoctorWorkingHourRepository : IDoctorWorkingHourRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorWorkingHourRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(DoctorWorkingHour workingHour)
    {
        await _context.DoctorWorkingHours.AddAsync(workingHour);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(DoctorWorkingHour workingHour)
    {
        _context.DoctorWorkingHours.Remove(workingHour);
        await _context.SaveChangesAsync();
    }

    public async Task<List<DoctorWorkingHour>> GetAllAsync()
    {
        return await _context.DoctorWorkingHours
            .Include(x => x.Doctor)
            .AsNoTracking()
            .OrderBy(x => x.DayOfWeek)
            .ThenBy(x => x.StartTime)
            .ToListAsync();
    }

    public async Task<DoctorWorkingHour?> GetByIdAsync(Guid id)
    {
        return await _context.DoctorWorkingHours
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(DoctorWorkingHour workingHour)
    {
        _context.DoctorWorkingHours.Update(workingHour);
        await _context.SaveChangesAsync();
    }

    public async Task<DoctorWorkingHour?> GetByDoctorAndDayAsync(
    Guid doctorId,
    DayOfWeek dayOfWeek)
    {
        return await _context.DoctorWorkingHours
            .FirstOrDefaultAsync(x =>
                x.DoctorId == doctorId &&
                x.DayOfWeek == dayOfWeek);
    }
}