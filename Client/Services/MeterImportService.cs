using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Collections.Generic;
using PoverkaWinForms.Settings;

namespace PoverkaWinForms.Services;

public class MeterImportService
{
    private readonly HttpClient _http;
    private readonly TokenService _tokens;
    private readonly Dictionary<(string ManufacturerName, string Type), int> _meterTypes = new();
    private readonly Dictionary<string, int> _registrations = new();
    private readonly HashSet<(int registrationId, string name)> _modifications = new();

    public MeterImportService(IHttpClientFactory factory, TokenService tokens, IdentityServerSettings settings)
    {
        _http = factory.CreateClient("ApiClient");
        _http.BaseAddress = new Uri(settings.Authority);
        _tokens = tokens;
    }

    public async Task ImportAsync(string path)
    {
        var token = await _tokens.GetAccessTokenAsync();
        if (token is null) return;

        await LoadExistingAsync(token);

        var culture = CultureInfo.GetCultureInfo("ru-RU");
        var lines = await File.ReadAllLinesAsync(path);
        foreach (var line in lines.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var parts = line.Split(';');
            if (parts.Length < 41)
            {
                continue;
            }
            var fullName = parts[0];
            var type = parts[1];
            var className = parts[2];
            var modificationName = parts[3];
            var registrationNumber = parts[4];
            var verificationInterval = short.Parse(parts[5], culture);
            var manufacturerName = parts[6];
            var pasportImpulseWeight = double.Parse(parts[7], culture);
            var verificationImpulseWeight = double.Parse(parts[8], culture);
            var qmin = double.Parse(parts[9], culture);
            var qt1 = double.Parse(parts[10], culture);
            var qt2 = double.Parse(parts[11], culture);
            var qmax = double.Parse(parts[12], culture);
            var checkpoint1 = double.Parse(parts[13], culture);
            var checkpoint1RequiredTime = double.Parse(parts[14], culture);
            var checkpoint1TimeMultiplier = double.Parse(parts[15], culture);
            var checkpoint1PulseCount = double.Parse(parts[16], culture);
            var checkpoint2 = double.Parse(parts[17], culture);
            var checkpoint2RequiredTime = double.Parse(parts[18], culture);
            var checkpoint2TimeMultiplier = double.Parse(parts[19], culture);
            var checkpoint2PulseCount = double.Parse(parts[20], culture);
            var checkpoint3 = double.Parse(parts[21], culture);
            var checkpoint3RequiredTime = double.Parse(parts[22], culture);
            var checkpoint3TimeMultiplier = double.Parse(parts[23], culture);
            var checkpoint3PulseCount = double.Parse(parts[24], culture);
            double? checkpoint4 = ParseNullableDouble(parts[25], culture);
            double? checkpoint4RequiredTime = ParseNullableDouble(parts[26], culture);
            double? checkpoint4TimeMultiplier = ParseNullableDouble(parts[27], culture);
            double? checkpoint4PulseCount = ParseNullableDouble(parts[28], culture);
            var numberOfMeasurements = byte.Parse(parts[29], culture);
            var minPulseCount = short.Parse(parts[30], culture);
            var measurementDuration = short.Parse(parts[31], culture);
            var verificationMethodology = parts[32];
            var relativeErrorQt1_Qmax = byte.Parse(parts[33], culture);
            var relativeErrorQt2_Qt1 = byte.Parse(parts[34], culture);
            var relativeErrorQmin_Qt2 = byte.Parse(parts[35], culture);
            var registrationDate = DateOnly.Parse(parts[36], culture);
            var endDate = DateOnly.Parse(parts[37], culture);
            var flowSetpointPercent = double.Parse(parts[38], culture);
            var hasVerificationModeByV = parts[39].Equals("да", StringComparison.OrdinalIgnoreCase);
            var hasVerificationModeByG = parts[40].Equals("да", StringComparison.OrdinalIgnoreCase);

            var meterTypeId = await CreateMeterTypeAsync(token, fullName, type, manufacturerName);
            var registrationId = await CreateRegistrationAsync(token, meterTypeId, registrationNumber, verificationInterval,
                verificationMethodology, relativeErrorQt1_Qmax, relativeErrorQt2_Qt1, relativeErrorQmin_Qt2, registrationDate,
                endDate, hasVerificationModeByV, hasVerificationModeByG);

            await CreateModificationAsync(
                token,
                registrationId,
                modificationName,
                className,
                pasportImpulseWeight,
                verificationImpulseWeight,
                qmin,
                qt1,
                qt2,
                qmax,
                checkpoint1,
                checkpoint1RequiredTime,
                checkpoint1TimeMultiplier,
                checkpoint1PulseCount,
                checkpoint2,
                checkpoint2RequiredTime,
                checkpoint2TimeMultiplier,
                checkpoint2PulseCount,
                checkpoint3,
                checkpoint3RequiredTime,
                checkpoint3TimeMultiplier,
                checkpoint3PulseCount,
                checkpoint4,
                checkpoint4RequiredTime,
                checkpoint4TimeMultiplier,
                checkpoint4PulseCount,
                numberOfMeasurements,
                minPulseCount,
                measurementDuration,
                flowSetpointPercent);
        }
    }

    private async Task LoadExistingAsync(string token)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/metertypes");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var items = await response.Content.ReadFromJsonAsync<List<MeterTypeDto>>();
            if (items != null)
            {
                foreach (var m in items)
                {
                    _meterTypes[(m.ManufacturerName, m.Type)] = m.Id;
                }
            }
        }

        request = new HttpRequestMessage(HttpMethod.Get, "/api/registrations");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        response = await _http.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var items = await response.Content.ReadFromJsonAsync<List<RegistrationDto>>();
            if (items != null)
            {
                foreach (var r in items)
                {
                    _registrations[r.RegistrationNumber] = r.Id;
                }
            }
        }

        request = new HttpRequestMessage(HttpMethod.Get, "/api/modifications");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        response = await _http.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var items = await response.Content.ReadFromJsonAsync<List<ModificationDto>>();
            if (items != null)
            {
                foreach (var m in items)
                {
                    _modifications.Add((m.RegistrationId, m.Name));
                }
            }
        }
    }

    private async Task<int> CreateMeterTypeAsync(string token, string fullName, string type, string manufacturerName)
    {
        if (_meterTypes.TryGetValue((manufacturerName, type), out var existingId))
        {
            return existingId;
        }

        var request = new HttpRequestMessage(HttpMethod.Post, "/api/metertypes")
        {
            Content = JsonContent.Create(new { EditorName = "import", Type = type, FullName = fullName, ManufacturerName = manufacturerName })
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var id = await response.Content.ReadFromJsonAsync<int>();
        _meterTypes[(manufacturerName, type)] = id;
        return id;
    }

    private async Task<int> CreateRegistrationAsync(string token, int meterTypeId, string registrationNumber,
        short verificationInterval, string verificationMethodology, byte relativeErrorQt1_Qmax,
        byte relativeErrorQt2_Qt1, byte relativeErrorQmin_Qt2, DateOnly registrationDate, DateOnly endDate,
        bool hasVerificationModeByV, bool hasVerificationModeByG)
    {
        if (_registrations.TryGetValue(registrationNumber, out var existingId))
        {
            return existingId;
        }

        var request = new HttpRequestMessage(HttpMethod.Post, "/api/registrations")
        {
            Content = JsonContent.Create(new
            {
                EditorName = "import",
                MeterTypeId = meterTypeId,
                RegistrationNumber = registrationNumber,
                VerificationInterval = verificationInterval,
                VerificationMethodology = verificationMethodology,
                RelativeErrorQt1_Qmax = relativeErrorQt1_Qmax,
                RelativeErrorQt2_Qt1 = relativeErrorQt2_Qt1,
                RelativeErrorQmin_Qt2 = relativeErrorQmin_Qt2,
                RegistrationDate = registrationDate,
                EndDate = endDate,
                HasVerificationModeByV = hasVerificationModeByV,
                HasVerificationModeByG = hasVerificationModeByG
            })
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var id = await response.Content.ReadFromJsonAsync<int>();
        _registrations[registrationNumber] = id;
        return id;
    }

    private async Task<int?> CreateModificationAsync(
        string token,
        int registrationId,
        string name,
        string className,
        double pasportImpulseWeight,
        double verificationImpulseWeight,
        double qmin,
        double qt1,
        double qt2,
        double qmax,
        double checkpoint1,
        double checkpoint1RequiredTime,
        double checkpoint1TimeMultiplier,
        double checkpoint1PulseCount,
        double checkpoint2,
        double checkpoint2RequiredTime,
        double checkpoint2TimeMultiplier,
        double checkpoint2PulseCount,
        double checkpoint3,
        double checkpoint3RequiredTime,
        double checkpoint3TimeMultiplier,
        double checkpoint3PulseCount,
        double? checkpoint4,
        double? checkpoint4RequiredTime,
        double? checkpoint4TimeMultiplier,
        double? checkpoint4PulseCount,
        byte numberOfMeasurements,
        short minPulseCount,
        short measurementDuration,
        double flowSetpointPercent)
    {
        if (!_modifications.Add((registrationId, name)))
        {
            return null;
        }

        var request = new HttpRequestMessage(HttpMethod.Post, "/api/modifications")
        {
            Content = JsonContent.Create(new
            {
                EditorName = "import",
                RegistrationId = registrationId,
                Name = name,
                ClassName = className,
                PasportImpulseWeight = pasportImpulseWeight,
                VerificationImpulseWeight = verificationImpulseWeight,
                Qmin = qmin,
                Qt1 = qt1,
                Qt2 = qt2,
                Qmax = qmax,
                Checkpoint1 = checkpoint1,
                Checkpoint1RequiredTime = checkpoint1RequiredTime,
                Checkpoint1TimeMultiplier = checkpoint1TimeMultiplier,
                Checkpoint1PulseCount = checkpoint1PulseCount,
                Checkpoint2 = checkpoint2,
                Checkpoint2RequiredTime = checkpoint2RequiredTime,
                Checkpoint2TimeMultiplier = checkpoint2TimeMultiplier,
                Checkpoint2PulseCount = checkpoint2PulseCount,
                Checkpoint3 = checkpoint3,
                Checkpoint3RequiredTime = checkpoint3RequiredTime,
                Checkpoint3TimeMultiplier = checkpoint3TimeMultiplier,
                Checkpoint3PulseCount = checkpoint3PulseCount,
                Checkpoint4 = checkpoint4,
                Checkpoint4RequiredTime = checkpoint4RequiredTime,
                Checkpoint4TimeMultiplier = checkpoint4TimeMultiplier,
                Checkpoint4PulseCount = checkpoint4PulseCount,
                NumberOfMeasurements = numberOfMeasurements,
                MinPulseCount = minPulseCount,
                MeasurementDurationInSeconds = measurementDuration,
                FlowSetpointPercent = flowSetpointPercent
            })
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var id = await response.Content.ReadFromJsonAsync<int>();
        _modifications.Add((registrationId, name));
        return id;
    }

    private static double? ParseNullableDouble(string value, CultureInfo culture) =>
        string.IsNullOrWhiteSpace(value) ? null : double.Parse(value, culture);

    private record MeterTypeDto(int Id, string ManufacturerName, string Type);
    private record RegistrationDto(int Id, string RegistrationNumber);
    private record ModificationDto(int Id, int RegistrationId, string Name);
}
