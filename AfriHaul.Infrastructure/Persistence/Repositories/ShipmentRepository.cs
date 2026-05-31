using AfriHaul.Domain.Entities;
using AfriHaul.Domain.Enums;
using AfriHaul.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfriHaul.Infrastructure.Persistence.Repositories;

public class ShipmentRepository : IShipmentRepository
{
    private readonly AfriHaulDbContext _context;

    public ShipmentRepository(AfriHaulDbContext context)
    {
        _context = context;
    }

    public async Task<Shipment?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _context.Shipments
            .Include(s => s.Shipper)
            .Include(s => s.Carrier)
            .FirstOrDefaultAsync(s => s.Id == id, ct);

    public async Task<IEnumerable<Shipment>> GetByShipperAsync(Guid shipperId, CancellationToken ct = default)
        => await _context.Shipments
            .Where(s => s.ShipperId == shipperId)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync(ct);

    public async Task<IEnumerable<Shipment>> GetPendingAsync(CancellationToken ct = default)
        => await _context.Shipments
            .Include(s => s.Shipper)
            .Where(s => s.Status == ShipmentStatus.Pending)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync(ct);

    public async Task<IEnumerable<Shipment>> GetByStatusAsync(ShipmentStatus status, CancellationToken ct = default)
        => await _context.Shipments
            .Include(s => s.Shipper)
            .Where(s => s.Status == status)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync(ct);

    public async Task AddAsync(Shipment shipment, CancellationToken ct = default)
        => await _context.Shipments.AddAsync(shipment, ct);

    public void Update(Shipment shipment)
        => _context.Shipments.Update(shipment);
}