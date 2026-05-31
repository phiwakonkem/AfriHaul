using AfriHaul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AfriHaul.Infrastructure.Persistence.Configurations;

public class FleetConfiguration : IEntityTypeConfiguration<Fleet>
{
    public void Configure(EntityTypeBuilder<Fleet> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.RegistrationPlate).IsRequired().HasMaxLength(20);
        builder.Property(f => f.MaxPayloadTons).HasPrecision(8, 2);
        builder.Property(f => f.CurrentLocationLandmark).HasMaxLength(200);
        builder.Property(f => f.VehicleType).HasConversion<string>();
    }
}