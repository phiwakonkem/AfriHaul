using AfriHaul.Domain.Entities;
using AfriHaul.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfriHaul.Infrastructure.Persistence.Repositories;

public class CarrierRepository : ICarrierRepository
{
    private readonly AfriHaulDbContext _context;

    public CarrierRepository(AfriHaulDbContext context)
    {
        _context = context;
    }

    public async Task<Carrier?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _context.Carriers
            .Include(c => c.Fleet)
            .FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task<IEnumerable<Carrier>> GetAvailableCarriersAsync(string country, CancellationToken ct = default)
        => await _context.Carriers
            .Include(c => c.Fleet)
            .Where(c => c.Country == country && c.IsVerified)
            .ToListAsync(ct);

    public async Task AddAsync(Carrier carrier, CancellationToken ct = default)
        => await _context.Carriers.AddAsync(carrier, ct);

    public void Update(Carrier carrier)
        => _context.Carriers.Update(carrier);
}