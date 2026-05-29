using AfriHaul.Domain.Common;
using AfriHaul.Domain.Enums;

namespace AfriHaul.Domain.Entities;

public class Fleet : BaseEntity
{
    public Guid CarrierId { get; private set; }
    public Carrier Carrier { get; private set; } = null!;
    public string RegistrationPlate { get; private set; } = string.Empty;
    public VehicleType VehicleType { get; private set; }
    public decimal MaxPayloadTons { get; private set; }
    public bool IsAvailable { get; private set; } = true;
    public string CurrentLocationLandmark { get; private set; } = string.Empty; // Africa-specific: landmark-based

    private Fleet() { }

    public static Fleet Create(Guid carrierId, string plate, VehicleType type,
                                decimal maxPayload, string currentLocation)
    {
        return new Fleet
        {
            CarrierId = carrierId,
            RegistrationPlate = plate,
            VehicleType = type,
            MaxPayloadTons = maxPayload,
            CurrentLocationLandmark = currentLocation
        };
    }

    public void SetAvailability(bool available)
    {
        IsAvailable = available;
        SetUpdated();
    }
}