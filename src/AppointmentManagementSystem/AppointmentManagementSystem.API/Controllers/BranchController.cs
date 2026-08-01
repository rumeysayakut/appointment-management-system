using AppointmentManagementSystem.Application.Features.Branches.Commands.CreateBranch;
using AppointmentManagementSystem.Application.Features.Branches.Queries.GetAllBranches;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagementSystem.Application.Features.Branches.Commands.UpdateBranch;
using AppointmentManagementSystem.Application.Features.Branches.Commands.DeleteBranch;

namespace AppointmentManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly IMediator _mediator;

    public BranchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBranchCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBranchesQuery());
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateBranchCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteBranchCommand
        {
            Id = id
        });

        return NoContent();
    }
}