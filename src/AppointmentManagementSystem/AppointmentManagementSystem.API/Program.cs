using AppointmentManagementSystem.Application.DependencyInjection;
using AppointmentManagementSystem.Persistence.DependencyInjection;
using AppointmentManagementSystem.Application.Common.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.Configure<AppointmentSettings>(
    builder.Configuration.GetSection("AppointmentSettings"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();