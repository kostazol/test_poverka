using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data.Configurations
{
    public class StateRegisterConfiguration : IEntityTypeConfiguration<StateRegister>
    {
        public void Configure(EntityTypeBuilder<StateRegister> builder)
        {
            builder.ToTable("StateRegisters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.RegisterNumber).HasColumnName("RegisterNumber");
            builder.Property(x => x.InstrumentName).HasColumnName("InstrumentName");
            builder.Property(x => x.VerificationDocument).HasColumnName("VerificationDocument");

        }
    }
}
