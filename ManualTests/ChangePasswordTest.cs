using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ManualTests;

public static class ChangePasswordTest
{
    public static async Task RunAsync()
    {
        var token = await TestCommon.GetTokenAsync("admin", "admin");
        var http = TestCommon.Http;

        var changeMessage = new HttpRequestMessage(HttpMethod.Put, "/api/users/password")
        {
            Content = JsonContent.Create(new { currentPassword = "admin", newPassword = "TempPass123!" })
        };
        changeMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        var changeResponse = await http.SendAsync(changeMessage);
        changeResponse.EnsureSuccessStatusCode();
        Console.WriteLine("Password changed successfully");

        var newToken = await TestCommon.GetTokenAsync("admin", "TempPass123!");
        Console.WriteLine("Login with new password succeeded");
    }
}

