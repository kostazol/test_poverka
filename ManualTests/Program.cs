using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

var http = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

async Task<TokenResponse> GetTokenAsync(string username, string password)
{
    var response = await http.PostAsync("/connect/token", new FormUrlEncodedContent(new Dictionary<string, string>
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

var token = await GetTokenAsync("admin", "admin");

var request = new HttpRequestMessage(HttpMethod.Get, "/api/users");
request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
var usersResponse = await http.SendAsync(request);
usersResponse.EnsureSuccessStatusCode();

var usersJson = await usersResponse.Content.ReadAsStringAsync();
Console.WriteLine(usersJson);

var changeMessage = new HttpRequestMessage(HttpMethod.Put, "/api/users/password")
{
    Content = JsonContent.Create(new
    {
        currentPassword = "admin",
        newPassword = "TempPass123!"
    })
};
changeMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
var changeResponse = await http.SendAsync(changeMessage);
changeResponse.EnsureSuccessStatusCode();
Console.WriteLine("Password changed successfully");

var newToken = await GetTokenAsync("admin", "TempPass123!");
Console.WriteLine("Login with new password succeeded");

record TokenResponse(
    [property: JsonPropertyName("access_token")] string AccessToken,
    [property: JsonPropertyName("refresh_token")] string RefreshToken,
    [property: JsonPropertyName("expires_in")] int ExpiresIn);

