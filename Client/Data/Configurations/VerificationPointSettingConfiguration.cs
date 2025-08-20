using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data.Configurations
{
    public class VerificationPointSettingConfiguration : IEntityTypeConfiguration<VerificationPointSetting>
    {
        public void Configure(EntityTypeBuilder<VerificationPointSetting> builder)
        {
            builder.ToTable("VerificationPointSettings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Diameter).HasColumnName("Diameter");
            builder.Property(x => x.MaxFlow).HasColumnName("MaxFlow");
            builder.Property(x => x.FlowPercentOfMax).HasColumnName("FlowPercentOfMax");
            builder.Property(x => x.TestFlow).HasColumnName("TestFlow");
            builder.Property(x => x.TestTime).HasColumnName("TestTime");
            builder.Property(x => x.ImpulseWeightImpPerL).HasColumnName("ImpulseWeightImpPerL");
            builder.Property(x => x.ImpulseWeightLPerImp).HasColumnName("ImpulseWeightLPerImp");
            builder.Property(x => x.ImpulseWeightM3PerImp).HasColumnName("ImpulseWeightM3PerImp");
            builder.Property(x => x.RelativeError).HasColumnName("RelativeError");
        }
    }
}
