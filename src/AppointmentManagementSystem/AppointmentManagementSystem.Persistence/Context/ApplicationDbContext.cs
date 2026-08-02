using AppointmentManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Branch> Branches => Set<Branch>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<DoctorWorkingHour> DoctorWorkingHours => Set<DoctorWorkingHour>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}