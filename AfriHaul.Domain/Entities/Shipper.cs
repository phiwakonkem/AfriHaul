using AfriHaul.Domain.Common;

namespace AfriHaul.Domain.Entities;

public class Shipper : BaseEntity
{
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Company { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty; // SA, ZW, ZM, etc.
    public bool IsVerified { get; private set; }

    public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    // EF Core constructor
    private Shipper() { }

    public static Shipper Create(string fullName, string email, string phone,
                                  string company, string country)
    {
        return new Shipper
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phone,
            Company = company,
            Country = country
        };
    }

    public void Verify() => IsVerified = true;
}