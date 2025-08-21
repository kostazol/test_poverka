using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using PoverkaServer;

namespace PoverkaServer.Models;

public class UserCreateRequest : IValidatableObject
{
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина UserName, допускается длина от 1 до 256 символов.")]
    public required string UserName { get; init; }

    [StringLength(16, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина Password, допускается длина от 1 до 16 символов.")]
    public required string Password { get; init; }

    public required string Role { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? LastName { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? FirstName { get; init; }

    [StringLength(100, ErrorMessage = "Указана недопустимая длина, допускается не больше 100 символов.")]
    public string? MiddleName { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Roles.All.Contains(Role))
            yield return new ValidationResult(
                $"Указана недопустимая роль. Допустимые значения: {string.Join(", ", Roles.All)}.",
                new[] { nameof(Role) });
    }
}

