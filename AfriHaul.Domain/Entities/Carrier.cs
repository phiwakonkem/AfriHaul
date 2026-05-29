using AfriHaul.Domain.Common;

namespace AfriHaul.Domain.Entities;

public class Carrier : BaseEntity
{
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string LicenseNumber { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public bool IsVerified { get; private set; }
    public double Rating { get; private set; } = 5.0;

    public ICollection<Fleet> Fleet { get; private set; } = new List<Fleet>();
    public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    private Carrier() { }

    public static Carrier Create(string fullName, string email, string phone,
                                  string license, string country)
    {
        return new Carrier
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phone,
            LicenseNumber = license,
            Country = country
        };
    }

    public void UpdateRating(double newRating)
    {
        Rating = Math.Round((Rating + newRating) / 2, 2);
        SetUpdated();
    }

    public void Verify() => IsVerified = true;
}