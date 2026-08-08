using AppointmentManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;
using AppointmentManagementSystem.Application.Features.Appointments.Queries.DoctorAppointments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagementSystem.Application.Features.Appointments.Queries.PatientAppointments;

namespace AppointmentManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateAppointmentCommand command)
    {
        var appointmentId = await _mediator.Send(command);

        return Ok(appointmentId);
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetDoctorAppointments(Guid doctorId)
    {
        var query = new GetDoctorAppointmentsQuery
        {
            DoctorId = doctorId
        };

        var appointments = await _mediator.Send(query);

        return Ok(appointments);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetPatientAppointments(Guid patientId)
    {
        var query = new GetPatientAppointmentsQuery
        {
            PatientId = patientId
        };

        var appointments = await _mediator.Send(query);

        return Ok(appointments);
    }
}