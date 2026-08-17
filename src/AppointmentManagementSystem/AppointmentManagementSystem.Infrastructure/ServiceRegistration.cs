using AppointmentManagementSystem.Application.Interfaces.ExternalServices;
using AppointmentManagementSystem.Infrastructure.ExternalServices;
using AppointmentManagementSystem.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagementSystem.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Mail ayarları
        services.Configure<MailSettings>(
            configuration.GetSection("MailSettings"));

        services.AddScoped<IEmailService, MailKitEmailService>();

        // Patient Priority servisi (HttpClient ile)
        services.AddHttpClient<IPatientPriorityService, PatientPriorityService>();

        return services;
    }
}