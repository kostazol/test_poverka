using System.Net.Http.Json;
using System.Text.Json.Serialization;
using PoverkaWinForms;

namespace PoverkaWinForms.Services;

public class TokenService
{
    private readonly HttpClient _http;
    private readonly IdentityServerSettings _settings;
    private string? _username;
    private string? _password;
    private string? _accessToken;
    private string? _refreshToken;
    private DateTime _expiresAt;

    public TokenService(IHttpClientFactory factory, IdentityServerSettings settings)
    {
        _http = factory.CreateClient();
        _settings = settings;
        _http.BaseAddress = new Uri(settings.Authority);
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        _username = username;
        _password = password;

        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = _settings.ClientId,
            ["client_secret"] = _settings.ClientSecret,
            ["grant_type"] = "password",
            ["username"] = username,
            ["password"] = password,
            ["scope"] = "api offline_access"
        });

        var response = await _http.PostAsync("/connect/token", content);
        if (!response.IsSuccessStatusCode)
            return false;

        var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
        if (token is null)
            return false;

        _accessToken = token.AccessToken;
        _refreshToken = token.RefreshToken;
        _expiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
        return true;
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        if (_accessToken is null)
            return null;

        if (DateTime.UtcNow >= _expiresAt)
        {
            var refreshed = await RefreshAsync();
            if (!refreshed && _username is not null && _password is not null)
                await LoginAsync(_username, _password);
        }

        return _accessToken;
    }

    private async Task<bool> RefreshAsync()
    {
        if (_refreshToken is null)
            return false;

        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = _settings.ClientId,
            ["client_secret"] = _settings.ClientSecret,
            ["grant_type"] = "refresh_token",
            ["refresh_token"] = _refreshToken
        });

        var response = await _http.PostAsync("/connect/token", content);
        if (!response.IsSuccessStatusCode)
            return false;

        var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
        if (token is null)
            return false;

        _accessToken = token.AccessToken;
        _refreshToken = token.RefreshToken;
        _expiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
        return true;
    }

    private record TokenResponse([property: JsonPropertyName("access_token")] string AccessToken, [property: JsonPropertyName("refresh_token")] string RefreshToken, [property: JsonPropertyName("expires_in")] int ExpiresIn);
}

