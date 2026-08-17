namespace AppointmentManagementSystem.Application.Interfaces.ExternalServices;

public interface IEmailService
{
    Task SendAsync(string to, string subject, string body);
}