using AppointmentManagementSystem.Application.Common.Settings;
using AppointmentManagementSystem.Application.DependencyInjection;
using AppointmentManagementSystem.Infrastructure;
using AppointmentManagementSystem.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);   // Bunu geri ekle
builder.Services.AddInfrastructureServices(builder.Configuration);

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