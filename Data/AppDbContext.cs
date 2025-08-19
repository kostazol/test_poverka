using Microsoft.EntityFrameworkCore;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TestRun> TestRuns => Set<TestRun>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<TestRun>();
            e.HasKey(x => x.Id);
            e.Property(x => x.Timestamp).HasColumnType("timestamp");
            e.OwnsOne(x => x.Meter, b =>
            {
                b.Property(m => m.Serial).HasColumnName("Meter_Serial").HasMaxLength(128);
                b.Property(m => m.Model).HasColumnName("Meter_Model").HasMaxLength(128);
                b.Property(m => m.DiameterMm).HasColumnName("Meter_DiameterMm");
                b.Property(m => m.Unit).HasColumnName("Meter_Unit").HasMaxLength(32);
            });
        }
    }
}
