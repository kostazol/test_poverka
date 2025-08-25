using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaServer.Domain;

namespace PoverkaServer.Data.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityByDefaultColumn();
        builder.Property(e => e.RegistrationNumber).HasMaxLength(100);
        builder.Property(e => e.VerificationMethodology).HasMaxLength(256);
        builder.Property(e => e.EditorName).HasMaxLength(256);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.UpdatedAt);
        builder.HasIndex(e => e.RegistrationNumber).IsUnique();
        builder.HasOne<MeterType>()
            .WithMany()
            .HasForeignKey(e => e.MeterTypeId);
    }
}
