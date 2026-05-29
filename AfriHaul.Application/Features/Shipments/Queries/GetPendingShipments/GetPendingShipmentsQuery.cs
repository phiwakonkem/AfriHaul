using MediatR;

namespace AfriHaul.Application.Features.Shipments.Queries.GetPendingShipments;

public record GetPendingShipmentsQuery() : IRequest<List<ShipmentDto>>;

public record ShipmentDto(
    Guid Id,
    string OriginCity,
    string OriginCountry,
    string DestinationCity,
    string DestinationCountry,
    decimal WeightTons,
    string CargoDescription,
    string Status,
    DateTime CreatedAt
);