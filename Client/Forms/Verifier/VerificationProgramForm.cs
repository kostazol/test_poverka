using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms.Verifier;

public partial class VerificationProgramForm : Form
{
    private readonly IReadOnlyList<FlowMeterInfo> _meters;

    private VerificationProgramForm()
    {
        InitializeComponent();
        _meters = Array.Empty<FlowMeterInfo>();
    }

    internal VerificationProgramForm(IReadOnlyList<FlowMeterInfo> meters)
    {
        InitializeComponent();
        _meters = meters;
    }

    private void VerificationProgramFormLoad(object? sender, EventArgs e)
    {
        if (DesignMode)
        {
            return;
        }

        (string label, Func<FlowMeterInfo, string?> selector)[] rows =
        {
            ("Полное наименование", m => m.MeterType?.FullName),
            ("Тип", m => m.MeterType?.Type),
            ("Модификация", m => m.Modification?.Name),
            ("Номер госреестра СИ", m => m.Registration?.RegistrationNumber),
            ("Межповерочный интервал (месяцев)", m => m.Registration is null ? null : (m.Registration.VerificationInterval * 12).ToString()),
            ("Межповерочный интервал", m => FormatYears(m.Registration?.VerificationInterval)),
            ("Изготовитель", m => m.Manufacturer?.Name),
            ("Режим поверки V, м3", m => ToYesNo(m.Registration?.HasVerificationModeByV)),
            ("Режим поверки Q, м3", m => ToYesNo(m.Registration?.HasVerificationModeByG)),
            ("Вес импульса, л/имп", m => m.Modification?.ImpulseWeight.ToString()),
            ("Измеренный вес импульса", _ => string.Empty),
            ("Кол-во импульсов (требуемое)", m => m.Modification?.MinPulseCount.ToString()),
            ("Время поверки, с", m => m.Modification?.MeasurementDurationInSeconds.ToString()),
            ("Qmax", m => m.Modification?.Qmax.ToString()),
            ("Методика поверки", m => m.Registration?.VerificationMethodology)
        };

        foreach (var (label, selector) in rows)
        {
            int rowIndex = ProgramDataGridView.Rows.Add();
            ProgramDataGridView.Rows[rowIndex].Cells[0].Value = label;

            for (int i = 0; i < _meters.Count && i < 6; i++)
            {
                ProgramDataGridView.Rows[rowIndex].Cells[i + 1].Value = selector(_meters[i]);
            }
        }
    }

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
}
