using AppointmentManagementSystem.Application.Features.Notifications.Queries.PatientNotifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetPatientNotifications(Guid patientId)
    {
        var query = new GetPatientNotificationsQuery
        {
            PatientId = patientId
        };

        var notifications = await _mediator.Send(query);

        return Ok(notifications);
    }
}