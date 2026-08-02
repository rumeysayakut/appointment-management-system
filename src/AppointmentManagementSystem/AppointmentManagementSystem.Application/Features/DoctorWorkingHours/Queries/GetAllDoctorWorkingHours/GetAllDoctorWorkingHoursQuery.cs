using MediatR;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Queries.GetAllDoctorWorkingHours;

public class GetAllDoctorWorkingHoursQuery : IRequest<List<DoctorWorkingHourDto>>
{
}