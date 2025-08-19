using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data.Configurations
{
    public class DiameterConfiguration : IEntityTypeConfiguration<Diameter>
    {
        public void Configure(EntityTypeBuilder<Diameter> builder)
        {
            builder.ToTable("Diameters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.StateRegisterId).HasColumnName("StateRegisterId");
            builder.Property(x => x.Value).HasColumnName("Value");

            builder.HasOne(x => x.StateRegister)
                   .WithMany(s => s.Diameters)
                   .HasForeignKey(x => x.StateRegisterId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
