using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms.Verifier;

internal record FlowMeterInfo(MeterTypeDto? MeterType, ManufacturerDto? Manufacturer, ModificationDto? Modification, RegistrationDto? Registration)
{
    private static string? ToYesNo(bool? value) => value is null ? null : value.Value ? "да" : "нет";

    private static string? FormatRelative(double? value) => value.HasValue ? $"±{value}" : null;

    private static string? FormatYears(short? years)
    {
        if (!years.HasValue)
            return null;

        var y = years.Value;
        var mod100 = y % 100;
        var mod10 = y % 10;
        var suffix = mod10 == 1 && mod100 != 11
            ? "год"
            : mod10 is >= 2 and <= 4 && (mod100 < 10 || mod100 >= 20)
                ? "года"
                : "лет";
        return $"{y} {suffix}";
    }

    public string? FullName => MeterType?.FullName;
    public string? Type => MeterType?.Type;
    public string? ModificationName => Modification?.Name;
    public string? RegistrationNumber => Registration?.RegistrationNumber;
    public string? VerificationIntervalMonths => Registration is null ? null : (Registration.VerificationInterval * 12).ToString();
    public string? VerificationInterval => FormatYears(Registration?.VerificationInterval);
    public string? ManufacturerName => Manufacturer?.Name;
    public string? VerificationModeByV => ToYesNo(Registration?.HasVerificationModeByV);
    public string? VerificationModeByG => ToYesNo(Registration?.HasVerificationModeByG);
    public string? ImpulseWeight => Modification?.ImpulseWeight.ToString();
    public string? MinPulseCount => Modification?.MinPulseCount.ToString();
    public string? MeasurementDurationInSeconds => Modification?.MeasurementDurationInSeconds.ToString();
    public string? Qmax => Modification?.Qmax.ToString();
    public string? VerificationMethodology => Registration?.VerificationMethodology;
    public string? Checkpoint1 => Modification?.Checkpoint1.ToString();
    public string? Checkpoint2 => Modification?.Checkpoint2.ToString();
    public string? Checkpoint3 => Modification?.Checkpoint3.ToString();
    public string? Checkpoint4 => Modification?.Checkpoint4.ToString();
    public string? NumberOfMeasurements => Modification?.NumberOfMeasurements.ToString();
    public string? RelativeErrorQt1Qmax => FormatRelative(Registration?.RelativeErrorQt1Qmax);
    public string? RelativeErrorQt2Qt1 => FormatRelative(Registration?.RelativeErrorQt2Qt1);

}
