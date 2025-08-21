namespace PoverkaServer.Models;

public record UserResponse(string Id, string UserName, string Role, string? LastName, string? FirstName, string? MiddleName);

