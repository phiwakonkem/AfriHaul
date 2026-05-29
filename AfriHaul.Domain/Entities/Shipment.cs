using AfriHaul.Domain.Common;
using AfriHaul.Domain.Enums;

namespace AfriHaul.Domain.Entities;

public class Shipment : BaseEntity
{
    public Guid ShipperId { get; private set; }
    public Shipper Shipper { get; private set; } = null!;

    public Guid? CarrierId { get; private set; }
    public Carrier? Carrier { get; private set; }

    public string OriginLandmark { get; private set; } = string.Empty;
    public string OriginCity { get; private set; } = string.Empty;
    public string OriginCountry { get; private set; } = string.Empty;

    public string DestinationLandmark { get; private set; } = string.Empty;
    public string DestinationCity { get; private set; } = string.Empty;
    public string DestinationCountry { get; private set; } = string.Empty;

    public decimal WeightTons { get; private set; }
    public string CargoDescription { get; private set; } = string.Empty;
    public VehicleType RequiredVehicleType { get; private set; }
    public ShipmentStatus Status { get; private set; } = ShipmentStatus.Pending;
    public decimal? AgreedPriceZAR { get; private set; }
    public DateTime? PickupDate { get; private set; }

    private Shipment() { }

    public static Shipment Create(Guid shipperId, string originLandmark, string originCity,
        string originCountry, string destinationLandmark, string destinationCity,
        string destinationCountry, decimal weightTons, string cargoDescription,
        VehicleType vehicleType)
    {
        return new Shipment
        {
            ShipperId = shipperId,
            OriginLandmark = originLandmark,
            OriginCity = originCity,
            OriginCountry = originCountry,
            DestinationLandmark = destinationLandmark,
            DestinationCity = destinationCity,
            DestinationCountry = destinationCountry,
            WeightTons = weightTons,
            CargoDescription = cargoDescription,
            RequiredVehicleType = vehicleType
        };
    }

    public void AssignCarrier(Guid carrierId, decimal agreedPrice)
    {
        CarrierId = carrierId;
        AgreedPriceZAR = agreedPrice;
        Status = ShipmentStatus.Matched;
        SetUpdated();
    }

    public void UpdateStatus(ShipmentStatus status)
    {
        Status = status;
        SetUpdated();
    }

    public void SetPickupDate(DateTime date)
    {
        PickupDate = date;
        SetUpdated();
    }
}