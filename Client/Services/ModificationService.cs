using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PoverkaWinForms.Settings;

namespace PoverkaWinForms.Services;

public class ModificationService
{
    private readonly HttpClient _http;
    private readonly TokenService _tokens;

    public ModificationService(IHttpClientFactory factory, TokenService tokens, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("ApiClient");
        _http.BaseAddress = new Uri(settings.Authority);
        _tokens = tokens;
    }

    public async Task<List<ModificationDto>> GetAllAsync(int meterTypeId, int manufacturerId, DateOnly manufactureDate)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null)
            return new();

        var url = $"/api/modifications?meterTypeId={meterTypeId}&manufacturerId={manufacturerId}&manufactureDate={manufactureDate:yyyy-MM-dd}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            return new();

        var items = await response.Content.ReadFromJsonAsync<List<ModificationDto>>();
        return items ?? new();
    }
}

public record ModificationDto(int Id, int RegistrationId, string RegistrationNumber, string Name);
