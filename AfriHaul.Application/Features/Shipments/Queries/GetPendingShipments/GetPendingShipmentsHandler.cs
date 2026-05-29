using AfriHaul.Domain.Interfaces;
using MediatR;

namespace AfriHaul.Application.Features.Shipments.Queries.GetPendingShipments;

public class GetPendingShipmentsHandler
    : IRequestHandler<GetPendingShipmentsQuery, List<ShipmentDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPendingShipmentsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ShipmentDto>> Handle(
        GetPendingShipmentsQuery request, CancellationToken ct)
    {
        var shipments = await _unitOfWork.Shipments.GetPendingAsync(ct);

        return shipments.Select(s => new ShipmentDto(
            s.Id,
            s.OriginCity,
            s.OriginCountry,
            s.DestinationCity,
            s.DestinationCountry,
            s.WeightTons,
            s.CargoDescription,
            s.Status.ToString(),
            s.CreatedAt
        )).ToList();
    }
}