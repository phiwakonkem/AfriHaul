using AfriHaul.Domain.Entities;

namespace AfriHaul.Domain.Interfaces;

public interface ICarrierRepository
{
    Task<Carrier?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Carrier>> GetAvailableCarriersAsync(string country, CancellationToken ct = default);
    Task AddAsync(Carrier carrier, CancellationToken ct = default);
    void Update(Carrier carrier);
}