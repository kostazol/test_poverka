using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PoverkaWinForms.Settings;

namespace PoverkaWinForms.Services;

public class ManufacturerService
{
    private readonly HttpClient _http;
    private readonly TokenService _tokens;
    private List<ManufacturerDto> _defaultManufacturers = new();

    public ManufacturerService(IHttpClientFactory factory, TokenService tokens, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("ApiClient");
        _http.BaseAddress = new Uri(settings.Authority);
        _tokens = tokens;
    }

    public async Task<List<ManufacturerDto>> GetAllAsync(string search, int? take = null)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            if (_defaultManufacturers.Count > 0)
                return _defaultManufacturers;
        }

        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return new();

        var url = "/api/manufacturers";
        if (!string.IsNullOrWhiteSpace(search) || take.HasValue)
        {
            var query = new List<string>();
            if (!string.IsNullOrWhiteSpace(search))
                query.Add($"search={Uri.EscapeDataString(search)}");
            if (take.HasValue)
                query.Add($"take={take.Value}");
            url += "?" + string.Join("&", query);
        }

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode) return new();

        var items = await response.Content.ReadFromJsonAsync<List<ManufacturerDto>>();
        items ??= new();

        if (string.IsNullOrWhiteSpace(search))
            _defaultManufacturers = items;

        return items;
    }
}

public record ManufacturerDto(int Id, string Name);
