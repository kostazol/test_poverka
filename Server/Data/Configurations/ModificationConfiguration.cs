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
        builder.Property(e => e.ClassName).HasMaxLength(5);
        builder.Property(e => e.ImpulseWeight).HasColumnType("double precision");
        builder.Property(e => e.Qmin).HasColumnType("double precision");
        builder.Property(e => e.Qt1).HasColumnType("double precision");
        builder.Property(e => e.Qt2).HasColumnType("double precision");
        builder.Property(e => e.Qmax).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint1).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint2).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint3).HasColumnType("double precision");
        builder.Property(e => e.Checkpoint4).HasColumnType("double precision");
        builder.Property(e => e.EditorName).HasMaxLength(256);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.UpdatedAt);
        builder.HasOne<Registration>()
            .WithMany()
            .HasForeignKey(e => e.RegistrationId);
    }
}
