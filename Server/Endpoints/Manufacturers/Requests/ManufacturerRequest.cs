using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Endpoints.Manufacturers.Requests;

public class ManufacturerRequest : IValidatableObject
{
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина EditorName, допускается длина от 1 до 256 символов.")]
    public required string EditorName { get; init; }

    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина Name, допускается длина от 1 до 256 символов.")]
    public required string Name { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        yield break;
    }
}
