using Microsoft.EntityFrameworkCore;
using PoverkaWinForms.Domain;
using PoverkaWinForms.Data.Configurations;

namespace PoverkaWinForms.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TestRun> TestRuns => Set<TestRun>();
        public DbSet<StateRegister> StateRegisters => Set<StateRegister>();
        public DbSet<Diameter> Diameters => Set<Diameter>();
        public DbSet<FlowmeterModification> FlowmeterModifications => Set<FlowmeterModification>();
        public DbSet<ParameterSetting> ParameterSettings => Set<ParameterSetting>();
        public DbSet<VerificationPointSetting> VerificationPointSettings => Set<VerificationPointSetting>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestRunConfiguration());
            modelBuilder.ApplyConfiguration(new StateRegisterConfiguration());
            modelBuilder.ApplyConfiguration(new DiameterConfiguration());
            modelBuilder.ApplyConfiguration(new FlowmeterModificationConfiguration());
            modelBuilder.ApplyConfiguration(new ParameterSettingConfiguration());
            modelBuilder.ApplyConfiguration(new VerificationPointSettingConfiguration());
        }
    }
}
