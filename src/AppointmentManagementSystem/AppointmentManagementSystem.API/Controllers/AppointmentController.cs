using AppointmentManagementSystem.Application.Features.Appointments.Commands.CancelAppointment;
using AppointmentManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;
using AppointmentManagementSystem.Application.Features.Appointments.Queries.DoctorAppointments;
using AppointmentManagementSystem.Application.Features.Appointments.Queries.PatientAppointments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagementSystem.Application.Features.Appointments.Commands.CompleteAppointment;
using AppointmentManagementSystem.Application.Features.Appointments.Commands.MarkAppointmentAsNoShow;
using AppointmentManagementSystem.Application.Features.Appointments.Queries.GetAvailableAppointmentSlots;

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

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
        await _mediator.Send(
            new CompleteAppointmentCommand
            {
                AppointmentId = id
            });

        return Ok();
    }

    [HttpPost("{id}/no-show")]
    public async Task<IActionResult> MarkAsNoShow(Guid id)
    {
        await _mediator.Send(new MarkAppointmentAsNoShowCommand
        {
            AppointmentId = id
        });

        return Ok();
    }

    [HttpPut("{id}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await _mediator.Send(
            new CancelAppointmentCommand
            {
                AppointmentId = id
            });

        return Ok();
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

    [HttpGet("available-slots")]
    public async Task<IActionResult> GetAvailableAppointmentSlots(
    Guid branchId,
    DateTime date)
    {
        var query = new GetAvailableAppointmentSlotsQuery
        {
            BranchId = branchId,
            Date = date
        };

        var availableSlots = await _mediator.Send(query);

        return Ok(availableSlots);
    }
}