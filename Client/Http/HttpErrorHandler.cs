using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using PoverkaWinForms.Exceptions;

namespace PoverkaWinForms.Http;

public class HttpErrorHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync(cancellationToken);
                var message = ParseErrorMessage(content);
                throw new ApiException(response.StatusCode, message);
            }
            return response;
        }
        catch (HttpRequestException ex)
        {
            throw new ServerUnavailableException(inner: ex);
        }
    }
    private static string? ParseErrorMessage(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return null;

        try
        {
            var errors = JsonSerializer.Deserialize<List<IdentityErrorDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (errors is { Count: > 0 })
                return string.Join("; ", errors.Select(e => e.Description));
        }
        catch
        {
            // ignore parsing errors
        }

        return content;
    }

    private record IdentityErrorDto(string Code, string Description);
}
