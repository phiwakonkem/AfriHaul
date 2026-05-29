namespace AfriHaul.Domain.Interfaces;

public interface IUnitOfWork
{
    IShipmentRepository Shipments { get; }
    ICarrierRepository Carriers { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}