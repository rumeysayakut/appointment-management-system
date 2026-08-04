using AppointmentManagementSystem.Application.Features.Patients.Commands.CreatePatient;
using AppointmentManagementSystem.Application.Features.Patients.Commands.DeletePatient;
using AppointmentManagementSystem.Application.Features.Patients.Commands.UpdatePatient;
using AppointmentManagementSystem.Application.Features.Patients.Queries.GetAllPatients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePatientCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPatientsQuery());
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdatePatientCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeletePatientCommand
        {
            Id = id
        });

        return NoContent();
    }
}