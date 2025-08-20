using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PoverkaWinForms;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddIdentityServerSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("IdentityServer").Get<IdentityServerSettings>()
            ?? throw new InvalidOperationException("IdentityServer settings are missing");
        if (string.IsNullOrWhiteSpace(settings.Authority) ||
            string.IsNullOrWhiteSpace(settings.ClientId) ||
            string.IsNullOrWhiteSpace(settings.ClientSecret))
        {
            throw new InvalidOperationException("IdentityServer settings are incomplete");
        }
        services.AddSingleton(settings);
        return services;
    }
}
