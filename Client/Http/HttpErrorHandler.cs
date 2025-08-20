using System.Net.Http;
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
                throw new ApiException(response.StatusCode, string.IsNullOrWhiteSpace(content) ? null : content);
            }
            return response;
        }
        catch (HttpRequestException ex)
        {
            throw new ServerUnavailableException(inner: ex);
        }
    }
}
