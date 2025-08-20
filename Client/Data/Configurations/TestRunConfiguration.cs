using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data.Configurations
{
    public class TestRunConfiguration : IEntityTypeConfiguration<TestRun>
    {
        public void Configure(EntityTypeBuilder<TestRun> builder)
        {
            builder.ToTable("TestRuns");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Timestamp).HasColumnName("Timestamp").HasColumnType("timestamp");
            builder.Property(x => x.VolumeLiters).HasColumnName("VolumeLiters");
            builder.Property(x => x.TimeSeconds).HasColumnName("TimeSeconds");
            builder.Property(x => x.IndicatedFlow).HasColumnName("IndicatedFlow");
            builder.Property(x => x.TemperatureC).HasColumnName("TemperatureC");
            builder.Property(x => x.PressureKPa).HasColumnName("PressureKPa");
            builder.Property(x => x.ActualFlow).HasColumnName("ActualFlow");
            builder.Property(x => x.ErrorPercent).HasColumnName("ErrorPercent");

            builder.OwnsOne(x => x.Meter, b =>
            {
                b.Property(m => m.Serial).HasColumnName("MeterSerial").HasMaxLength(128);
                b.Property(m => m.Model).HasColumnName("MeterModel").HasMaxLength(128);
                b.Property(m => m.DiameterMm).HasColumnName("MeterDiameterMm");
                b.Property(m => m.Unit).HasColumnName("MeterUnit").HasMaxLength(32);
            });
        }
    }
}
