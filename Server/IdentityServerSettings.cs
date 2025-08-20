namespace PoverkaServer;

public class IdentityServerSettings
{
    public required string Authority { get; init; }

    public required bool RequireHttpsMetadata { get; init; }
}

