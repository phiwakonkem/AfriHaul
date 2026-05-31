using AfriHaul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AfriHaul.Infrastructure.Persistence.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.OriginLandmark).IsRequired().HasMaxLength(200);
        builder.Property(s => s.OriginCity).IsRequired().HasMaxLength(100);
        builder.Property(s => s.OriginCountry).IsRequired().HasMaxLength(50);
        builder.Property(s => s.DestinationLandmark).IsRequired().HasMaxLength(200);
        builder.Property(s => s.DestinationCity).IsRequired().HasMaxLength(100);
        builder.Property(s => s.DestinationCountry).IsRequired().HasMaxLength(50);
        builder.Property(s => s.WeightTons).HasPrecision(8, 2);
        builder.Property(s => s.AgreedPriceZAR).HasPrecision(12, 2);
        builder.Property(s => s.CargoDescription).HasMaxLength(500);
        builder.Property(s => s.Status).HasConversion<string>();
        builder.Property(s => s.RequiredVehicleType).HasConversion<string>();
    }
}