using AfriHaul.Domain.Interfaces;
using AfriHaul.Infrastructure.Persistence;
using AfriHaul.Infrastructure.Persistence.Repositories;

namespace AfriHaul.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AfriHaulDbContext _context;

    public UnitOfWork(AfriHaulDbContext context)
    {
        _context = context;
        Shipments = new ShipmentRepository(context);
        Carriers = new CarrierRepository(context);
    }

    public IShipmentRepository Shipments { get; }
    public ICarrierRepository Carriers { get; }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);
}