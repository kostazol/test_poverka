using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data.Configurations
{
    public class ParameterSettingConfiguration : IEntityTypeConfiguration<ParameterSetting>
    {
        public void Configure(EntityTypeBuilder<ParameterSetting> builder)
        {
            builder.ToTable("ParameterSettings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.RegisterNumber).HasColumnName("RegisterNumber");
            builder.Property(x => x.SerialNumber).HasColumnName("SerialNumber");
            builder.Property(x => x.InstrumentName).HasColumnName("InstrumentName");
            builder.Property(x => x.VerificationDocument).HasColumnName("VerificationDocument");
            builder.Property(x => x.Modification).HasColumnName("Modification");
        }
    }
}
