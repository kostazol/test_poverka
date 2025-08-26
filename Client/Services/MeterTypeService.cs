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
    private List<MeterTypeDto> _defaultTypes = new();

    public MeterTypeService(IHttpClientFactory factory, TokenService tokens, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("ApiClient");
        _http.BaseAddress = new Uri(settings.Authority);
        _tokens = tokens;
    }

    public async Task<List<MeterTypeDto>> GetAllAsync(string search, int? take = null)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            if (_defaultTypes.Count > 0)
                return _defaultTypes;
        }

        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return new();

        var url = "/api/metertypes";
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

        var items = await response.Content.ReadFromJsonAsync<List<MeterTypeDto>>();
        items ??= new();

        if (string.IsNullOrWhiteSpace(search))
            _defaultTypes = items;

        return items;
    }
}

public record MeterTypeDto(int Id, string Type, string FullName);
