using System.Net.Http.Headers;

namespace ManualTests;

public static class GetUsersTest
{
    public static async Task RunAsync()
    {
        var token = await TestCommon.GetTokenAsync("admin", "admin");
        var http = TestCommon.Http;

        var request = new HttpRequestMessage(HttpMethod.Get, "/api/users");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        var usersResponse = await http.SendAsync(request);
        usersResponse.EnsureSuccessStatusCode();
        var usersJson = await usersResponse.Content.ReadAsStringAsync();
        Console.WriteLine(usersJson);
    }
}

