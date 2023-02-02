using ExpertSender.Application.Persons.Commands.CreateNew;
using ExpertSender.Application.Persons.Commands.DeleteExisting;
using ExpertSender.Application.Persons.Commands.UpdateExisting;
using ExpertSender.Application.Persons.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExperSender.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController: ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
        return Ok(result.Persons);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePersonCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeletePersonCommand(id), cancellationToken);
        return Ok();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateNewPersonCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}
