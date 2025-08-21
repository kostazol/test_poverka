using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Models;

public class UserUpdateRequest
{
    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? LastName { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? FirstName { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? MiddleName { get; init; }

    [StringLength(150, ErrorMessage = "Указана недопустимая длина, допускается не больше 150 символов.")]
    public string? Position { get; init; }
}

