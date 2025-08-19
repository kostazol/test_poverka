using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using PoverkaWinForms.Data;
using PoverkaWinForms.Services;
using System.Linq;

namespace PoverkaWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IRunRepository, EfRepository>();
            services.AddScoped<MainForm>();
            services.AddScoped<MetersSetupForm>();

            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();
#if DEBUG
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var pending = db.Database.GetPendingMigrations().Any();
            if (pending)
            {
                db.Database.Migrate();
                DbSeeder.Seed(db);
            }
#endif
            Application.Run(scope.ServiceProvider.GetRequiredService<MetersSetupForm>());
        }
    }
}
