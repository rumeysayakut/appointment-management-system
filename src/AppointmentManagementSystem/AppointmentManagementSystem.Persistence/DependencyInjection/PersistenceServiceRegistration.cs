using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Persistence.Context;
using AppointmentManagementSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagementSystem.Persistence.DependencyInjection;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IBranchRepository, BranchRepository>();

        services.AddScoped<IDoctorRepository, DoctorRepository>();

        services.AddScoped<IDoctorWorkingHourRepository, DoctorWorkingHourRepository>();

        services.AddScoped<IPatientRepository, PatientRepository>();

        return services;
    }
}