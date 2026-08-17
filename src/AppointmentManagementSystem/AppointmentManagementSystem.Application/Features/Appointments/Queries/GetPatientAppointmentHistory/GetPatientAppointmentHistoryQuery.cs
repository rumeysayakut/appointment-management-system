using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetPatientAppointmentHistory;

public class GetPatientAppointmentHistoryQuery
    : IRequest<List<PatientAppointmentHistoryDto>>
{
    public string IdentityNumber { get; set; } = string.Empty;
}