using AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.CreateDoctorLeave;
using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.UpdateDoctorLeave;

namespace AppointmentManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorLeaveController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDoctorLeaveRepository _doctorLeaveRepository;

    public DoctorLeaveController(
        IMediator mediator,
        IDoctorLeaveRepository doctorLeaveRepository)
    {
        _mediator = mediator;
        _doctorLeaveRepository = doctorLeaveRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateDoctorLeaveCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    Guid id,
    UpdateDoctorLeaveCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return Ok();
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetByDoctorId(Guid doctorId)
    {
        var leaves = await _doctorLeaveRepository
            .GetByDoctorIdAsync(doctorId);

        return Ok(leaves);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var doctorLeave = await _doctorLeaveRepository.GetByIdAsync(id);

        if (doctorLeave is null)
            return NotFound("Doctor leave not found.");

        await _doctorLeaveRepository.DeleteAsync(doctorLeave);

        return NoContent();
    }
}