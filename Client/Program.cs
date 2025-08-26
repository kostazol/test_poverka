using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using PoverkaWinForms.Forms.Admin;
using PoverkaWinForms.Forms.Verifier;
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
            services.AddHttpClient("ApiClient")
                .AddHttpMessageHandler<HttpErrorHandler>();
            services.AddTransient<UserService>();
            services.AddTransient<MeterImportService>();
            services.AddTransient<MeterTypeService>();

            services.AddScoped<MetersSetupForm>();
            services.AddScoped<ConfigurationForm>();
            services.AddScoped<LoginForm>();

            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            Application.Run(scope.ServiceProvider.GetRequiredService<LoginForm>());
        }
    }
}
