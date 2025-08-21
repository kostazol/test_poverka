using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using PoverkaWinForms;
using PoverkaWinForms.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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
    public string? Role { get; private set; }

    public TokenService(IHttpClientFactory factory, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("AuthClient");
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

        var request = new HttpRequestMessage(HttpMethod.Post, "/connect/token")
        {
            Content = content
        };

        try
        {
            var response = await _http.SendAsync(request);
            var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (token is null)
                return false;

            _accessToken = token.AccessToken;
            _refreshToken = token.RefreshToken;
            _expiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token.AccessToken);
            Role = jwt.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
            return true;
        }
        catch (ApiException ex) when (ex.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Unauthorized)
        {
            return false;
        }

        // other ApiException or ServerUnavailableException will bubble up
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

        var request = new HttpRequestMessage(HttpMethod.Post, "/connect/token")
        {
            Content = content
        };

        try
        {
            var response = await _http.SendAsync(request);
            var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (token is null)
                return false;

            _accessToken = token.AccessToken;
            _refreshToken = token.RefreshToken;
            _expiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
            return true;
        }
        catch (ApiException ex) when (ex.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Unauthorized)
        {
            return false;
        }
    }

    private record TokenResponse([property: JsonPropertyName("access_token")] string AccessToken, [property: JsonPropertyName("refresh_token")] string RefreshToken, [property: JsonPropertyName("expires_in")] int ExpiresIn);
}

