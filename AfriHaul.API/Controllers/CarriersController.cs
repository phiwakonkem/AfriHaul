using AfriHaul.Domain.Entities;
using AfriHaul.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AfriHaul.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarriersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CarriersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("available/{country}")]
    public async Task<IActionResult> GetAvailable(string country, CancellationToken ct)
    {
        var carriers = await _unitOfWork.Carriers.GetAvailableCarriersAsync(country, ct);
        return Ok(carriers);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarrierRequest request, CancellationToken ct)
    {
        var carrier = Carrier.Create(
            request.FullName,
            request.Email,
            request.PhoneNumber,
            request.LicenseNumber,
            request.Country);

        await _unitOfWork.Carriers.AddAsync(carrier, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return CreatedAtAction(nameof(GetAvailable),
            new { country = carrier.Country },
            new { carrier.Id });
    }
}

public record CreateCarrierRequest(
    string FullName,
    string Email,
    string PhoneNumber,
    string LicenseNumber,
    string Country);