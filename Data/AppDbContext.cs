using Microsoft.EntityFrameworkCore;
using PoverkaWinForms.Domain;
using PoverkaWinForms.Data.Configurations;

namespace PoverkaWinForms.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TestRun> TestRuns => Set<TestRun>();
        public DbSet<StateRegister> StateRegisters => Set<StateRegister>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestRunConfiguration());
            modelBuilder.ApplyConfiguration(new StateRegisterConfiguration());
        }
    }
}
