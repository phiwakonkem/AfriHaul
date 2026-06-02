using AfriHaul.Application.Features.Shipments.Commands.CreateShipment;
using AfriHaul.Application.Features.Shipments.Queries.GetPendingShipments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AfriHaul.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShipmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetPending(CancellationToken ct)
    {
        var result = await _mediator.Send(new GetPendingShipmentsQuery(), ct);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateShipmentCommand command, CancellationToken ct)
    {
        var id = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(GetPending), new { id }, new { id });
    }
}