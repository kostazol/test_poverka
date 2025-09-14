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
            var fullName = parts[0];
            var type = parts[1];
            var className = parts[2];
            var modificationName = parts[3];
            var registrationNumber = parts[4];
            var verificationInterval = short.Parse(parts[5], culture);
            var manufacturerName = parts[6];
            var impulseWeight = double.Parse(parts[7], culture);
            var qmin = double.Parse(parts[8], culture);
            var qt1 = double.Parse(parts[9], culture);
            var qt2 = double.Parse(parts[10], culture);
            var qmax = double.Parse(parts[11], culture);
            var checkpoint1 = double.Parse(parts[12], culture);
            var checkpoint2 = double.Parse(parts[13], culture);
            var checkpoint3 = double.Parse(parts[14], culture);
            double? checkpoint4 = string.IsNullOrWhiteSpace(parts[15]) ? null : double.Parse(parts[15], culture);
            var numberOfMeasurements = byte.Parse(parts[16], culture);
            var minPulseCount = short.Parse(parts[17], culture);
            var measurementDuration = short.Parse(parts[18], culture);
            var verificationMethodology = parts[19];
            var relativeErrorQt1_Qmax = byte.Parse(parts[20], culture);
            var relativeErrorQt2_Qt1 = byte.Parse(parts[21], culture);
            var relativeErrorQmin_Qt2 = byte.Parse(parts[22], culture);
            var registrationDate = DateOnly.Parse(parts[23], culture);
            var endDate = DateOnly.Parse(parts[24], culture);
            var relativeErrorWithStandartValue = byte.Parse(parts[25], culture);
            var hasVerificationModeByV = parts[26].Equals("да", StringComparison.OrdinalIgnoreCase);
            var hasVerificationModeByG = parts[27].Equals("да", StringComparison.OrdinalIgnoreCase);

            var meterTypeId = await CreateMeterTypeAsync(token, fullName, type, manufacturerName);
            var registrationId = await CreateRegistrationAsync(token, meterTypeId, registrationNumber, verificationInterval,
                verificationMethodology, relativeErrorQt1_Qmax, relativeErrorQt2_Qt1, relativeErrorQmin_Qt2, registrationDate,
                endDate, hasVerificationModeByV, hasVerificationModeByG);

            await CreateModificationAsync(token, registrationId, modificationName, className, impulseWeight, qmin, qt1, qt2, qmax, checkpoint1,
                checkpoint2, checkpoint3, checkpoint4, numberOfMeasurements, minPulseCount, measurementDuration,
                relativeErrorWithStandartValue);
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

    private async Task<int?> CreateModificationAsync(string token, int registrationId, string name, string className,
        double impulseWeight, double qmin, double qt1, double qt2, double qmax, double checkpoint1,
        double checkpoint2, double checkpoint3, double? checkpoint4, byte numberOfMeasurements,
        short minPulseCount, short measurementDuration, byte relativeErrorWithStandartValue)
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
                ImpulseWeight = impulseWeight,
                Qmin = qmin,
                Qt1 = qt1,
                Qt2 = qt2,
                Qmax = qmax,
                Checkpoint1 = checkpoint1,
                Checkpoint2 = checkpoint2,
                Checkpoint3 = checkpoint3,
                Checkpoint4 = checkpoint4,
                NumberOfMeasurements = numberOfMeasurements,
                MinPulseCount = minPulseCount,
                MeasurementDurationInSeconds = measurementDuration,
                RelativeErrorWithStandartValue = relativeErrorWithStandartValue
            })
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var id = await response.Content.ReadFromJsonAsync<int>();
        _modifications.Add((registrationId, name));
        return id;
    }

    private record MeterTypeDto(int Id, string ManufacturerName, string Type);
    private record RegistrationDto(int Id, string RegistrationNumber);
    private record ModificationDto(int Id, int RegistrationId, string Name);
}
