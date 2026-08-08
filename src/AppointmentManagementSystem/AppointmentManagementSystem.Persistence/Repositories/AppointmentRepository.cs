using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Persistence.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _context.Appointments
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Appointment>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await _context.Appointments
            .AsNoTracking()
            .Include(x => x.Patient)
            .Where(x => x.DoctorId == doctorId)
            .OrderBy(x => x.StartTime)
            .ToListAsync();
    }

    public async Task<List<Appointment>> GetByPatientIdAsync(Guid patientId)
    {
        return await _context.Appointments
            .AsNoTracking()
            .Include(x => x.Doctor)
            .Where(x => x.PatientId == patientId)
            .OrderByDescending(x => x.StartTime)
            .ToListAsync();
    }

    public async Task<Appointment?> GetByDoctorAndStartTimeAsync(
    Guid doctorId,
    DateTime startTime)
    {
        return await _context.Appointments
            .FirstOrDefaultAsync(x =>
                x.DoctorId == doctorId &&
                x.StartTime == startTime);
    }
}