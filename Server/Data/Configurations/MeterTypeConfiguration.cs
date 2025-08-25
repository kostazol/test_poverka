using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaServer.Domain;

namespace PoverkaServer.Data.Configurations;

public class MeterTypeConfiguration : IEntityTypeConfiguration<MeterType>
{
    public void Configure(EntityTypeBuilder<MeterType> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityByDefaultColumn();
        builder.Property(e => e.Type).HasMaxLength(100);
        builder.Property(e => e.FullName).HasMaxLength(256);
        builder.Property(e => e.EditorName).HasMaxLength(256);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.UpdatedAt);
        builder.HasIndex(e => e.Type).IsUnique();
    }
}
