using AfriHaul.Domain.Enums;
using MediatR;

namespace AfriHaul.Application.Features.Shipments.Commands.CreateShipment;

public record CreateShipmentCommand(
    Guid ShipperId,
    string OriginLandmark,
    string OriginCity,
    string OriginCountry,
    string DestinationLandmark,
    string DestinationCity,
    string DestinationCountry,
    decimal WeightTons,
    string CargoDescription,
    VehicleType RequiredVehicleType
) : IRequest<Guid>;