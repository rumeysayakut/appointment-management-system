using AppointmentManagementSystem.Domain.Entities;

namespace AppointmentManagementSystem.Application.Interfaces.Persistence;

public interface IDoctorWorkingHourRepository
{
    Task<List<DoctorWorkingHour>> GetAllAsync();

    Task<DoctorWorkingHour?> GetByIdAsync(Guid id);

    Task AddAsync(DoctorWorkingHour workingHour);

    Task UpdateAsync(DoctorWorkingHour workingHour);

    Task DeleteAsync(DoctorWorkingHour workingHour);

    Task<DoctorWorkingHour?> GetByDoctorAndDayAsync(
        Guid doctorId,
        DayOfWeek dayOfWeek);
}