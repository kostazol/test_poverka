using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PoverkaWinForms.Data;

#nullable disable

namespace PoverkaWinForms.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "9.0.8");

            modelBuilder.Entity("PoverkaWinForms.Domain.StateRegister", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnName("Id").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
                b.Property<string>("InstrumentName").HasColumnName("InstrumentName");
                b.Property<string>("RegisterNumber").HasColumnName("RegisterNumber");
                b.Property<string>("VerificationDocument").HasColumnName("VerificationDocument");
                b.HasKey("Id");
                b.ToTable("StateRegisters");
            });

            modelBuilder.Entity("PoverkaWinForms.Domain.Diameter", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnName("Id").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
                b.Property<int?>("StateRegisterId").HasColumnName("StateRegisterId");
                b.Property<int>("Value").HasColumnName("Value");
                b.HasKey("Id");
                b.HasIndex("StateRegisterId");
                b.ToTable("Diameters");
            });

            modelBuilder.Entity("PoverkaWinForms.Domain.FlowmeterModification", b =>
            {
                b.Property<string>("Modification").HasColumnName("Modification");
                b.Property<int?>("StateRegisterId").HasColumnName("StateRegisterId");
                b.HasKey("Modification");
                b.HasIndex("StateRegisterId");
                b.ToTable("FlowmeterModifications");
            });

            modelBuilder.Entity("PoverkaWinForms.Domain.ParameterSetting", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnName("Id").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
                b.Property<string>("InstrumentName").HasColumnName("InstrumentName");
                b.Property<string>("Modification").HasColumnName("Modification");
                b.Property<string>("RegisterNumber").HasColumnName("RegisterNumber");
                b.Property<string>("SerialNumber").HasColumnName("SerialNumber");
                b.Property<string>("VerificationDocument").HasColumnName("VerificationDocument");
                b.HasKey("Id");
                b.ToTable("ParameterSettings");
            });

            modelBuilder.Entity("PoverkaWinForms.Domain.VerificationPointSetting", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnName("Id").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
                b.Property<string>("Diameter").HasColumnName("Diameter");
                b.Property<decimal?>("FlowPercentOfMax").HasColumnName("FlowPercentOfMax");
                b.Property<decimal?>("ImpulseWeightImpPerL").HasColumnName("ImpulseWeightImpPerL");
                b.Property<decimal?>("ImpulseWeightLPerImp").HasColumnName("ImpulseWeightLPerImp");
                b.Property<decimal?>("ImpulseWeightM3PerImp").HasColumnName("ImpulseWeightM3PerImp");
                b.Property<decimal?>("MaxFlow").HasColumnName("MaxFlow");
                b.Property<decimal?>("RelativeError").HasColumnName("RelativeError");
                b.Property<decimal?>("TestFlow").HasColumnName("TestFlow");
                b.Property<int?>("TestTime").HasColumnName("TestTime");
                b.HasKey("Id");
                b.ToTable("VerificationPointSettings");
            });

            modelBuilder.Entity("PoverkaWinForms.Domain.TestRun", b =>
            {
                b.Property<Guid>("Id").HasColumnName("Id");
                b.Property<double>("ActualFlow").HasColumnName("ActualFlow");
                b.Property<double>("ErrorPercent").HasColumnName("ErrorPercent");
                b.Property<double>("IndicatedFlow").HasColumnName("IndicatedFlow");
                b.Property<double>("PressureKPa").HasColumnName("PressureKPa");
                b.Property<double>("TemperatureC").HasColumnName("TemperatureC");
                b.Property<double>("TimeSeconds").HasColumnName("TimeSeconds");
                b.Property<double>("VolumeLiters").HasColumnName("VolumeLiters");
                b.Property<DateTime>("Timestamp").HasColumnType("timestamp").HasColumnName("Timestamp");
                b.Property<double>("MeterDiameterMm").HasColumnName("MeterDiameterMm");
                b.Property<string>("MeterModel").HasMaxLength(128).HasColumnName("MeterModel");
                b.Property<string>("MeterSerial").HasMaxLength(128).HasColumnName("MeterSerial");
                b.Property<string>("MeterUnit").HasMaxLength(32).HasColumnName("MeterUnit");
                b.HasKey("Id");
                b.ToTable("TestRuns");
            });

            modelBuilder.Entity("PoverkaWinForms.Domain.Diameter", b =>
            {
                b.HasOne("PoverkaWinForms.Domain.StateRegister", "StateRegister")
                    .WithMany("Diameters")
                    .HasForeignKey("StateRegisterId")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity("PoverkaWinForms.Domain.FlowmeterModification", b =>
            {
                b.HasOne("PoverkaWinForms.Domain.StateRegister", "StateRegister")
                    .WithMany("FlowmeterModifications")
                    .HasForeignKey("StateRegisterId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
