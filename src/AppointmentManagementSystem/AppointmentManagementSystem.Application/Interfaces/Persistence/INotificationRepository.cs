using AppointmentManagementSystem.Domain.Entities;

namespace AppointmentManagementSystem.Application.Interfaces.Persistence;

public interface INotificationRepository
{
    Task AddAsync(Notification notification);

    Task<List<Notification>> GetByPatientIdAsync(Guid patientId);
}