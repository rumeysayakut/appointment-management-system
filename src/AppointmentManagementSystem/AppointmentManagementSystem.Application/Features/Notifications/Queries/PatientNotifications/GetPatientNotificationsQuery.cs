using AppointmentManagementSystem.Application.Features.Notifications.DTOs;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Notifications.Queries.PatientNotifications;

public class GetPatientNotificationsQuery : IRequest<List<NotificationDto>>
{
    public Guid PatientId { get; set; }
}