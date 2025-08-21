using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Models;

public class ChangePasswordRequest
{
    [StringLength(16, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина Password, допускается длина от 1 до 16 символов.")]
    public required string CurrentPassword { get; init; }

    [StringLength(16, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина Password, допускается длина от 1 до 16 символов.")]
    public required string NewPassword { get; init; }
}
