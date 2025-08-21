using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Models;

public class UserUpdateRequest
{
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина UserName, допускается длина от 1 до 256 символов.")]
    public required string UserName { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? LastName { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? FirstName { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? MiddleName { get; init; }
}

