using System.Collections.Generic;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms.Verifier;

internal record FlowMeterInfo(
    MeterTypeDto? MeterType,
    ManufacturerDto? Manufacturer,
    ModificationDto? Modification,
    RegistrationDto? Registration)
{
    private static string ToYesNo(bool? value) => value == true ? "да" : "нет";

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

    public IEnumerable<(string Label, string? Value)> Rows
    {
        get
        {
            yield return ("Полное наименование", MeterType?.FullName);
            yield return ("Тип", MeterType?.Type);
            yield return ("Модификация", Modification?.Name);
            yield return ("Номер госреестра СИ", Registration?.RegistrationNumber);
            yield return ("Межповерочный интервал (месяцев)", Registration is null ? null : (Registration.VerificationInterval * 12).ToString());
            yield return ("Межповерочный интервал", FormatYears(Registration?.VerificationInterval));
            yield return ("Изготовитель", Manufacturer?.Name);
            yield return ("Режим поверки V, м3", ToYesNo(Registration?.HasVerificationModeByV));
            yield return ("Режим поверки Q, м3", ToYesNo(Registration?.HasVerificationModeByG));
            yield return ("Вес импульса, л/имп", Modification?.ImpulseWeight.ToString());
            yield return ("Измеренный вес импульса", string.Empty);
            yield return ("Кол-во импульсов (требуемое)", Modification?.MinPulseCount.ToString());
            yield return ("Время поверки, с", Modification?.MeasurementDurationInSeconds.ToString());
            yield return ("Qmax", Modification?.Qmax.ToString());
            yield return ("Методика поверки", Registration?.VerificationMethodology);
        }
    }
}
