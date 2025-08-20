using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace PoverkaServer;

public static class IdentityConfig
{
    public static IEnumerable<ApiScope> ApiScopes => new[]
    {
        new ApiScope("api", "Main API")
    };

    public static IEnumerable<ApiResource> ApiResources => new[]
    {
        new ApiResource("api", "Main API")
        {
            Scopes = { "api" },
            UserClaims = { JwtClaimTypes.Role }
        }
    };

    public static IEnumerable<Client> Clients => new[]
    {
        new Client
        {
            ClientId = "client",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = { "api", IdentityServerConstants.StandardScopes.OfflineAccess },
            AllowOfflineAccess = true
        }
    };
}
