using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PoverkaWinForms.Settings;

namespace PoverkaWinForms.Services;

public class MeterTypeService
{
    private readonly HttpClient _http;
    private readonly TokenService _tokens;

    public MeterTypeService(IHttpClientFactory factory, TokenService tokens, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("ApiClient");
        _http.BaseAddress = new Uri(settings.Authority);
        _tokens = tokens;
    }

    public async Task<List<MeterTypeDto>> GetAllAsync(string search)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return new();

        var url = string.IsNullOrWhiteSpace(search)
            ? "/api/metertypes"
            : $"/api/metertypes?search={Uri.EscapeDataString(search)}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode) return new();

        var items = await response.Content.ReadFromJsonAsync<List<MeterTypeDto>>();
        return items ?? new();
    }
}

public record MeterTypeDto(int Id, string Type, string FullName);
