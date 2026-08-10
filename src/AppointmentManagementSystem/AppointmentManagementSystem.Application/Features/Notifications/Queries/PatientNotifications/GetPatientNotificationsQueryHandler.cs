using AppointmentManagementSystem.Application.Features.Notifications.DTOs;
using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Notifications.Queries.PatientNotifications;

public class GetPatientNotificationsQueryHandler
    : IRequestHandler<GetPatientNotificationsQuery, List<NotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetPatientNotificationsQueryHandler(
        INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<List<NotificationDto>> Handle(
        GetPatientNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var notifications = await _notificationRepository
            .GetByPatientIdAsync(request.PatientId);

        return notifications.Select(x => new NotificationDto
        {
            Id = x.Id,
            PatientId = x.PatientId,
            AppointmentId = x.AppointmentId,
            Message = x.Message,
            IsRead = x.IsRead
        }).ToList();
    }
}