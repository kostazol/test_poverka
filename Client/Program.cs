using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using PoverkaWinForms.Forms;
using PoverkaWinForms.Data;
using PoverkaWinForms.Services;
using PoverkaWinForms.Http;

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

            services.AddIdentityServerSettings(configuration);
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<HttpErrorHandler>();
            services.AddHttpClient("AuthClient")
                .AddHttpMessageHandler<HttpErrorHandler>();
            services.AddSingleton<TokenService>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IRunRepository, EfRepository>();
            services.AddScoped<MainForm>();
            services.AddScoped<MetersSetupForm>();
            services.AddScoped<LoginForm>();

            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            Application.Run(scope.ServiceProvider.GetRequiredService<LoginForm>());
        }
    }
}
