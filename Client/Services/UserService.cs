using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;
using PoverkaWinForms;

namespace PoverkaWinForms.Services;

public class UserService
{
    private readonly HttpClient _http;
    private readonly TokenService _tokens;

    public UserService(IHttpClientFactory factory, TokenService tokens, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("ApiClient");
        _http.BaseAddress = new Uri(settings.Authority);
        _tokens = tokens;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null)
            return Enumerable.Empty<UserDto>();

        var request = new HttpRequestMessage(HttpMethod.Get, "/api/users");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var users = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
        return users ?? Enumerable.Empty<UserDto>();
    }

    public async Task CreateUserAsync(UserCreateDto user)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return;

        var request = new HttpRequestMessage(HttpMethod.Post, "/api/users")
        {
            Content = JsonContent.Create(user)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateUserAsync(string id, UserUpdateDto user)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return;

        var request = new HttpRequestMessage(HttpMethod.Put, $"/api/users/{id}")
        {
            Content = JsonContent.Create(user)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    public async Task SetPasswordAsync(string id, SetPasswordDto dto)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return;

        var request = new HttpRequestMessage(HttpMethod.Put, $"/api/users/{id}/password")
        {
            Content = JsonContent.Create(dto)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    public async Task ChangePasswordAsync(ChangePasswordDto dto)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return;

        var request = new HttpRequestMessage(HttpMethod.Put, "/api/users/password")
        {
            Content = JsonContent.Create(dto)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }
}

public record UserDto(string Id, string UserName, string Role, string? LastName, string? FirstName, string? MiddleName, string? Position);
public record UserCreateDto(string UserName, string Password, string Role, string? LastName, string? FirstName, string? MiddleName, string? Position);
public record UserUpdateDto(string? LastName, string? FirstName, string? MiddleName, string? Position);
public record SetPasswordDto(string Password);
public record ChangePasswordDto(string CurrentPassword, string NewPassword);

