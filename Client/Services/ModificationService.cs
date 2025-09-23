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

    public async Task<List<ModificationDto>> GetAllAsync(int meterTypeId, string manufacturerName, DateOnly manufactureDate)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null)
            return new();

        var url = $"/api/modifications?meterTypeId={meterTypeId}&manufacturerName={Uri.EscapeDataString(manufacturerName)}&manufactureDate={manufactureDate:yyyy-MM-dd}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            return new();

        var items = await response.Content.ReadFromJsonAsync<List<ModificationDto>>();
        return items ?? new();
    }
}

public record ModificationDto(
    int Id,
    int RegistrationId,
    string RegistrationNumber,
    string Name,
    string ClassName,
    double PasportImpulseWeight,
    double VerificationImpulseWeight,
    double Qmin,
    double Qt1,
    double Qt2,
    double Qmax,
    double Checkpoint1,
    double Checkpoint1RequiredTime,
    double Checkpoint1TimeMultiplier,
    double Checkpoint1PulseCount,
    double Checkpoint2,
    double Checkpoint2RequiredTime,
    double Checkpoint2TimeMultiplier,
    double Checkpoint2PulseCount,
    double Checkpoint3,
    double Checkpoint3RequiredTime,
    double Checkpoint3TimeMultiplier,
    double Checkpoint3PulseCount,
    double? Checkpoint4,
    double? Checkpoint4RequiredTime,
    double? Checkpoint4TimeMultiplier,
    double? Checkpoint4PulseCount,
    byte NumberOfMeasurements,
    short MinPulseCount,
    short MeasurementDurationInSeconds,
    double FlowSetpointPercent);
