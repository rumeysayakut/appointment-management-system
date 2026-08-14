using AppointmentManagementSystem.Application.Interfaces.ExternalServices;
using AppointmentManagementSystem.Infrastructure.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagementSystem.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddHttpClient<IPatientPriorityService, PatientPriorityService>(
            client =>
            {
                client.BaseAddress = new Uri(
                    "https://appointment-priority.free.beeceptor.com/");
            });

        return services;
    }
}