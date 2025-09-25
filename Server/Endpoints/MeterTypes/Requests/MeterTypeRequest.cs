using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Endpoints.MeterTypes.Requests;

public class MeterTypeRequest : IValidatableObject
{
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина EditorName, допускается длина от 1 до 256 символов.")]
    public required string EditorName { get; init; }

    [StringLength(100, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина Type, допускается длина от 1 до 100 символов.")]
    public required string Type { get; init; }

    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина FullName, допускается длина от 1 до 256 символов.")]
    public required string FullName { get; init; }

    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина ManufacturerName, допускается длина от 1 до 256 символов.")]
    public required string ManufacturerName { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        yield break;
    }
}

