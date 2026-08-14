using MediatR;

namespace AppointmentManagementSystem.Application.Features.Appointments.Queries.GetAvailableAppointmentSlots;

public class GetAvailableAppointmentSlotsQuery
    : IRequest<List<AvailableAppointmentSlotDto>>
{
    public Guid BranchId { get; set; }

    public Guid PatientId { get; set; }

    public bool HasPriorityRequest { get; set; }

    public DateTime Date { get; set; }
}