using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

var http = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

var tokenResponse = await http.PostAsync("/connect/token", new FormUrlEncodedContent(new Dictionary<string, string>
{
    ["client_id"] = "client",
    ["client_secret"] = "secret",
    ["grant_type"] = "password",
    ["username"] = "admin",
    ["password"] = "admin",
    ["scope"] = "api offline_access"
}));

tokenResponse.EnsureSuccessStatusCode();
var token = await tokenResponse.Content.ReadFromJsonAsync<TokenResponse>();
if (token is null)
{
    Console.WriteLine("Token response was null");
    return;
}

var request = new HttpRequestMessage(HttpMethod.Get, "/api/users");
request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
var usersResponse = await http.SendAsync(request);
usersResponse.EnsureSuccessStatusCode();

var usersJson = await usersResponse.Content.ReadAsStringAsync();
Console.WriteLine(usersJson);

record TokenResponse(
    [property: JsonPropertyName("access_token")] string AccessToken,
    [property: JsonPropertyName("refresh_token")] string RefreshToken,
    [property: JsonPropertyName("expires_in")] int ExpiresIn);
