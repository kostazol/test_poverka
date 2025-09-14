using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Endpoints.Modifications.Requests;

public class ModificationRequest : IValidatableObject
{
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина EditorName, допускается длина от 1 до 256 символов.")]
    public required string EditorName { get; init; }

    [Range(1, int.MaxValue, ErrorMessage = "RegistrationId должен быть положительным.")]
    public required int RegistrationId { get; init; }

    [StringLength(100, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина Name, допускается длина от 1 до 100 символов.")]
    public required string Name { get; init; }

    [StringLength(5, MinimumLength = 1, ErrorMessage = "Указана недопустимая длина ClassName, допускается длина от 1 до 5 символов.")]
    public required string ClassName { get; init; }

    [Range(0, double.MaxValue, ErrorMessage = "PasportImpulseWeight должен быть положительным.")]
    public required double PasportImpulseWeight { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "VerificationImpulseWeight должен быть положительным.")]
    public required double VerificationImpulseWeight { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Qmin должен быть положительным.")]
    public required double Qmin { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Qt1 должен быть положительным.")]
    public required double Qt1 { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Qt2 должен быть положительным.")]
    public required double Qt2 { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Qmax должен быть положительным.")]
    public required double Qmax { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Checkpoint1 должен быть положительным.")]
    public required double Checkpoint1 { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Checkpoint2 должен быть положительным.")]
    public required double Checkpoint2 { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Checkpoint3 должен быть положительным.")]
    public required double Checkpoint3 { get; init; }
    [Range(0, double.MaxValue, ErrorMessage = "Checkpoint4 должен быть положительным.")]
    public double? Checkpoint4 { get; init; }
    [Range(0, byte.MaxValue, ErrorMessage = "NumberOfMeasurements должен быть положительным.")]
    public required byte NumberOfMeasurements { get; init; }
    [Range(0, short.MaxValue, ErrorMessage = "MinPulseCount должен быть положительным.")]
    public required short MinPulseCount { get; init; }
    [Range(0, short.MaxValue, ErrorMessage = "MeasurementDurationInSeconds должен быть положительным.")]
    public required short MeasurementDurationInSeconds { get; init; }
    [Range(0, byte.MaxValue, ErrorMessage = "RelativeErrorWithStandartValue должен быть положительным.")]
    public required byte RelativeErrorWithStandartValue { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        yield break;
    }
}

