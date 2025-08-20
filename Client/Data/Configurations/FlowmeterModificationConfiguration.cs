using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data.Configurations
{
    public class FlowmeterModificationConfiguration : IEntityTypeConfiguration<FlowmeterModification>
    {
        public void Configure(EntityTypeBuilder<FlowmeterModification> builder)
        {
            builder.ToTable("FlowmeterModifications");
            builder.HasKey(x => x.Modification);
            builder.Property(x => x.Modification).HasColumnName("Modification");
            builder.Property(x => x.StateRegisterId).HasColumnName("StateRegisterId");

            builder.HasOne(x => x.StateRegister)
                   .WithMany(s => s.FlowmeterModifications)
                   .HasForeignKey(x => x.StateRegisterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
