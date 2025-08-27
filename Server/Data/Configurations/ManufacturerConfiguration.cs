using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaServer.Domain;

namespace PoverkaServer.Data.Configurations;

public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityByDefaultColumn();
        builder.Property(e => e.Name).HasMaxLength(256);
        builder.Property(e => e.EditorName).HasMaxLength(256);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.UpdatedAt);
        builder.HasIndex(e => e.Name).IsUnique();
    }
}
