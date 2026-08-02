using MediatR;

namespace AppointmentManagementSystem.Application.Features.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsQuery : IRequest<List<DoctorListDto>>
{
}