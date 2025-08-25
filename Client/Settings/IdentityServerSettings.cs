namespace PoverkaWinForms.Settings;

public class IdentityServerSettings
{
    public required string Authority { get; init; }

    public required string ClientId { get; init; }

    public required string ClientSecret { get; init; }
}

