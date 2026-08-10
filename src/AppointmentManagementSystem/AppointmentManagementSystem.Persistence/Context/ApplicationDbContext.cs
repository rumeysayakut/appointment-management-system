using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Configurations;
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

    public DbSet<Notification> Notifications { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<DoctorLeave> DoctorLeaves => Set<DoctorLeave>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
    }
}