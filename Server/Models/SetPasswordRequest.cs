using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Models;

public class SetPasswordRequest
{
    [StringLength(16, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина Password, допускается длина от 1 до 16 символов.")]
    public required string Password { get; init; }
}

