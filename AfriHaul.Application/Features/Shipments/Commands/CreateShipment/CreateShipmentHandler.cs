using AfriHaul.Domain.Entities;
using AfriHaul.Domain.Interfaces;
using MediatR;

namespace AfriHaul.Application.Features.Shipments.Commands.CreateShipment;

public class CreateShipmentHandler : IRequestHandler<CreateShipmentCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateShipmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateShipmentCommand request, CancellationToken ct)
    {
        var shipment = Shipment.Create(
            request.ShipperId,
            request.OriginLandmark,
            request.OriginCity,
            request.OriginCountry,
            request.DestinationLandmark,
            request.DestinationCity,
            request.DestinationCountry,
            request.WeightTons,
            request.CargoDescription,
            request.RequiredVehicleType
        );

        await _unitOfWork.Shipments.AddAsync(shipment, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return shipment.Id;
    }
}