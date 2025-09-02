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

    private void VerificationProgramForm_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
        {
            return;
        }

        var rows = new (string Label, Func<FlowMeterInfo, string?> Selector)[]
        {
            ("Полное наименование", m => m.FullName),
            ("Тип", m => m.Type),
            ("Модификация", m => m.ModificationName),
            ("Номер госреестра СИ", m => m.RegistrationNumber),
            ("Межповерочный интервал (месяцев)", m => m.VerificationIntervalMonths),
            ("Межповерочный интервал", m => m.VerificationInterval),
            ("Изготовитель", m => m.ManufacturerName),
            ("Режим поверки V, м3", m => m.VerificationModeByV),
            ("Режим поверки Q, м3", m => m.VerificationModeByG),
            ("Вес импульса, л/имп", m => m.ImpulseWeight),
            ("Измеренный вес импульса", m => m.MeasuredImpulseWeight),
            ("Кол-во импульсов (требуемое)", m => m.MinPulseCount),
            ("Время поверки, с", m => m.MeasurementDurationInSeconds),
            ("Qmax", m => m.Qmax),
            ("Методика поверки", m => m.VerificationMethodology)
        };

        foreach (var row in rows)
        {
            int rowIndex = ProgramDataGridView.Rows.Add();
            ProgramDataGridView.Rows[rowIndex].Cells[0].Value = row.Label;

            for (int i = 0; i < _meters.Count && i < 6; i++)
            {
                ProgramDataGridView.Rows[rowIndex].Cells[i + 1].Value = row.Selector(_meters[i]);
            }
        }
    }
}
