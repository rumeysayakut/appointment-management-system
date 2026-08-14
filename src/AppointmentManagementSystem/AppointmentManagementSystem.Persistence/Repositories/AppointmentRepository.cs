using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using AppointmentManagementSystem.Domain.Enums;

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
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
                .ThenInclude(d => d.Branch)
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
                x.StartTime == startTime &&
                x.Status != AppointmentStatus.CancelledByPatient &&
                x.Status != AppointmentStatus.CancelledByDoctor);
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetPriorityWindowAppointmentCountAsync(
    Guid doctorId,
    DateTime appointmentDate,
    DateTime priorityWindowStart,
    DateTime normalOpenTime)
    {
        var dayStart = appointmentDate.Date;
        var dayEnd = dayStart.AddDays(1);

        return await _context.Appointments.CountAsync(x =>
            x.DoctorId == doctorId &&
            x.StartTime >= dayStart &&
            x.StartTime < dayEnd &&
            x.CreatedAt >= priorityWindowStart &&
            x.CreatedAt < normalOpenTime &&
            x.Status != AppointmentStatus.CancelledByPatient &&
            x.Status != AppointmentStatus.CancelledByDoctor);
    }
}