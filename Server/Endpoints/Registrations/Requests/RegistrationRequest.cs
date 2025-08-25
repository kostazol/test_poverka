using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Endpoints.Registrations.Requests;

public class RegistrationRequest : IValidatableObject
{
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина EditorName, допускается длина от 1 до 256 символов.")]
    public required string EditorName { get; init; }

    [Range(1, int.MaxValue, ErrorMessage = "MeterTypeId должен быть положительным.")]
    public required int MeterTypeId { get; init; }

    [StringLength(100, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина RegistrationNumber, допускается длина от 1 до 100 символов.")]
    public required string RegistrationNumber { get; init; }

    [Range(1, short.MaxValue, ErrorMessage = "VerificationInterval должен быть положительным.")]
    public required short VerificationInterval { get; init; }

    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина VerificationMethodology, допускается длина от 1 до 256 символов.")]
    public required string VerificationMethodology { get; init; }
    [Range(0, byte.MaxValue, ErrorMessage = "RelativeErrorQt1_Qmax должен быть положительным.")]
    public required byte RelativeErrorQt1_Qmax { get; init; }
    [Range(0, byte.MaxValue, ErrorMessage = "RelativeErrorQt2_Qt1 должен быть положительным.")]
    public required byte RelativeErrorQt2_Qt1 { get; init; }
    [Range(0, byte.MaxValue, ErrorMessage = "RelativeErrorQmin_Qt2 должен быть положительным.")]
    public required byte RelativeErrorQmin_Qt2 { get; init; }
    public required DateOnly RegistrationDate { get; init; }
    public required DateOnly EndDate { get; init; }
    public required bool HasVerificationModeByV { get; init; }
    public required bool HasVerificationModeByG { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndDate < RegistrationDate)
        {
            yield return new ValidationResult(
                "EndDate не может быть раньше RegistrationDate.",
                new[] { nameof(EndDate) });
        }
    }
}

