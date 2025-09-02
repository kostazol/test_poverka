using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PoverkaWinForms.Settings;

namespace PoverkaWinForms.Services;

public class RegistrationService
{
    private readonly HttpClient _http;
    private readonly TokenService _tokens;

    public RegistrationService(IHttpClientFactory factory, TokenService tokens, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("ApiClient");
        _http.BaseAddress = new Uri(settings.Authority);
        _tokens = tokens;
    }

    public async Task<RegistrationDto?> GetAsync(int id)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null)
            return null;

        var request = new HttpRequestMessage(HttpMethod.Get, $"/api/registrations/{id}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<RegistrationDto>();
    }
}

public record RegistrationDto(
    int Id,
    string RegistrationNumber,
    short VerificationInterval,
    string VerificationMethodology,
    bool HasVerificationModeByV,
    bool HasVerificationModeByG);
