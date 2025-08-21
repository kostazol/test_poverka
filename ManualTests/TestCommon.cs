using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ManualTests;

public static class TestCommon
{
    public static HttpClient Http { get; } = new() { BaseAddress = new Uri("http://localhost:5000") };

    public static async Task<TokenResponse> GetTokenAsync(string username, string password)
    {
        var response = await Http.PostAsync("/connect/token", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = "client",
            ["client_secret"] = "secret",
            ["grant_type"] = "password",
            ["username"] = username,
            ["password"] = password,
            ["scope"] = "api offline_access"
        }));

        response.EnsureSuccessStatusCode();
        var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return token ?? throw new InvalidOperationException("Token response was null");
    }

    public record TokenResponse(
        [property: JsonPropertyName("access_token")] string AccessToken,
        [property: JsonPropertyName("refresh_token")] string RefreshToken,
        [property: JsonPropertyName("expires_in")] int ExpiresIn);
}


