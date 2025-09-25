using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaServer.Domain;

namespace PoverkaServer.Data.Configurations;

public class ModificationConfiguration : IEntityTypeConfiguration<Modification>
{
    public void Configure(EntityTypeBuilder<Modification> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityByDefaultColumn();
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.ClassName).HasMaxLength(5);
        builder.Property(e => e.PasportImpulseWeight).HasColumnType("double precision");
        builder.Property(e => e.VerificationImpulseWeight).HasColumnType("double precision");
        builder.Property(e => e.Qmin).HasColumnType("double precision");
        builder.Property(e => e.Qt1).HasColumnType("double precision");
        builder.Property(e => e.Qt2).HasColumnType("double precision");
        builder.Property(e => e.Qmax).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint1).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint1RequiredTime).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint1TimeMultiplier).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint1PulseCount).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint2).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint2RequiredTime).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint2TimeMultiplier).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint2PulseCount).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint3).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint3RequiredTime).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint3TimeMultiplier).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint3PulseCount).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint4).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint4RequiredTime).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint4TimeMultiplier).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint4PulseCount).HasColumnType("double precision");
        builder.Property(e => e.EditorName).HasMaxLength(256);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.UpdatedAt);
        builder.Property(e => e.FlowSetpointPercent).HasColumnType("double precision");
        builder.HasIndex(e => new { e.RegistrationId, e.Name }).IsUnique();
        builder.HasOne<Registration>()
            .WithMany()
            .HasForeignKey(e => e.RegistrationId);
    }
}
