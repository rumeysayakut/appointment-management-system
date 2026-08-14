namespace AppointmentManagementSystem.Application.Interfaces.ExternalServices;

public interface IPatientPriorityService
{
    Task<bool> IsPriorityPatientAsync(string identityNumber);
}