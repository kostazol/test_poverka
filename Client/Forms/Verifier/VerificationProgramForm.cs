using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms.Verifier;

public partial class VerificationProgramForm : Form
{
    private readonly IReadOnlyList<FlowMeterInfo> _meters;

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

        var rows = new (string Label, Func<FlowMeterInfo, string?> Get)[]
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
            ("Измененный вес импульса", _ => string.Empty),
            ("Кол-во импульсов (требуемое)", m => m.MinPulseCount),
            ("Кол-во импульсов (расчетное)", m => m.CalculatedPulseCount),
            ("Время поверки, с", m => m.MeasurementDurationInSeconds),
            ("Измененное время поверки", _ => string.Empty),
            ("Qmax", m => m.Qmax),
            ("Методика поверки", m => m.VerificationMethodology),
            ("Кол-во изм-й в точке", m => m.NumberOfMeasurements),
            ("Котрольная точка 1", m => m.Checkpoint1),
            ("Измененное кол-во импульсов", _ => string.Empty),
            ("Предел отн. погрешности, % ( Qt1-Qmax)", m => m.RelativeErrorQt1Qmax),
            ("Котрольная точка 2", m => m.Checkpoint2),
            ("Измененное кол-во импульсов", _ => string.Empty),
            ("Предел отн. погрешности, % ( Qt2-Qt1)", m => m.RelativeErrorQt2Qt1),
            ("Котрольная точка 3", m => m.Checkpoint3),
            ("Измененное кол-во импульсов", _ => string.Empty),
            ("Предел отн. погрешности, % ( Qt1-Qmax)", m => m.RelativeErrorQt1Qmax),
            ("Котрольная точка 4", m => m.Checkpoint4),
            ("Измененное кол-во импульсов", _ => string.Empty),
            ("Предел отн. погрешности, % ( Qt2-Qt1)", m => m.RelativeErrorQt2Qt1)
        };

        foreach (var row in rows)
        {
            int gridRow = ProgramDataGridView.Rows.Add();
            var dataGridViewRow = ProgramDataGridView.Rows[gridRow];
            dataGridViewRow.Cells[0].Value = row.Label;
            dataGridViewRow.Cells[0].ReadOnly = true;

            for (int i = 0; i < _meters.Count && i < 6; i++)
            {
                var cell = dataGridViewRow.Cells[i + 1];
                var value = row.Get(_meters[i]);
                cell.Value = value;
                cell.ReadOnly = true;
                cell.Style.BackColor = Color.LightGray;

                if (row.Label == "Кол-во импульсов (расчетное)" &&
                    _meters[i].Modification is not null &&
                    double.TryParse(_meters[i].MinPulseCount, NumberStyles.Any, CultureInfo.InvariantCulture, out var required) &&
                    double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var calculated) &&
                    required > calculated)
                {
                    cell.Style.BackColor = Color.MistyRose;
                }
            }
            for (int i = _meters.Count; i < 6; i++)
            {
                var cell = dataGridViewRow.Cells[i + 1];
                cell.ReadOnly = true;
                cell.Style.BackColor = Color.LightGray;
            }

            if (row.Label == "Методика поверки")
            {
                dataGridViewRow.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewRow.Height *= 4;
            }
            else if (row.Label.StartsWith("Полное наименование"))
            {
                dataGridViewRow.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewRow.Height = (int)(dataGridViewRow.Height * 2.5);
            }
        }
    }
}
