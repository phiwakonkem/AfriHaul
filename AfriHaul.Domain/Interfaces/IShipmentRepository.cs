using AfriHaul.Domain.Entities;
using AfriHaul.Domain.Enums;

namespace AfriHaul.Domain.Interfaces;

public interface IShipmentRepository
{
    Task<Shipment?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Shipment>> GetByShipperAsync(Guid shipperId, CancellationToken ct = default);
    Task<IEnumerable<Shipment>> GetPendingAsync(CancellationToken ct = default);
    Task<IEnumerable<Shipment>> GetByStatusAsync(ShipmentStatus status, CancellationToken ct = default);
    Task AddAsync(Shipment shipment, CancellationToken ct = default);
    void Update(Shipment shipment);
}