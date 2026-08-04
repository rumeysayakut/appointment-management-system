using AppointmentManagementSystem.Application.Features.Patients.DTOs;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Patients.Queries.GetAllPatients;

public class GetAllPatientsQuery : IRequest<List<PatientDto>>
{
}