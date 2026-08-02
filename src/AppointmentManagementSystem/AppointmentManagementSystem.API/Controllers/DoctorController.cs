using AppointmentManagementSystem.Application.Features.Doctors.Commands.CreateDoctor;
using AppointmentManagementSystem.Application.Features.Doctors.Commands.DeleteDoctor;
using AppointmentManagementSystem.Application.Features.Doctors.Commands.UpdateDoctor;
using AppointmentManagementSystem.Application.Features.Doctors.Queries.GetAllDoctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllDoctorsQuery());
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateDoctorCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteDoctorCommand
        {
            Id = id
        });

        return NoContent();
    }
}