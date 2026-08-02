using AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.CreateDoctorWorkingHour;
using AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.DeleteDoctorWorkingHour;
using AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.UpdateDoctorWorkingHour;
using AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Queries.GetAllDoctorWorkingHours;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorWorkingHourController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorWorkingHourController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorWorkingHourCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllDoctorWorkingHoursQuery());
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateDoctorWorkingHourCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteDoctorWorkingHourCommand
        {
            Id = id
        });

        return NoContent();
    }
}