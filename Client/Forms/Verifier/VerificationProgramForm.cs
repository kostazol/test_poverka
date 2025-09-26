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
            ("Паспортный вес импульса, л/имп", m => m.PasportImpulseWeight),
            ("Вес импульса для поверки, л/имп", m => m.VerificationImpulseWeight),
            ("Кол-во импульсов (требуемое)", m => m.MinPulseCount),
            ("Кол-во импульсов (расчетное)", m => m.CalculatedPulseCount),
            ("Время поверки, с", m => m.MeasurementDurationInSeconds),
            ("Qmax", m => m.Qmax),
            ("Методика поверки", m => m.VerificationMethodology),
            ("Кол-во изм-й в точке", m => m.NumberOfMeasurements),
            ("Котрольная точка 1", m => m.Checkpoint1),
            ("КТ1 Требуемое время (для 500 импульсов, не менее 60 с)", m => m.Checkpoint1RequiredTime),
            ("КТ1 Во сколько раз увеличить время", m => m.Checkpoint1TimeMultiplier),
            ("КТ1 Кол-во импульсов за 60 с", m => m.Checkpoint1PulseCount),
            ("Предел отн. погрешности, % ( Qt1-Qmax)", m => m.RelativeErrorQt1Qmax),
            ("Котрольная точка 2", m => m.Checkpoint2),
            ("КТ2 Требуемое время (для 500 импульсов, не менее 60 с)", m => m.Checkpoint2RequiredTime),
            ("КТ2 Во сколько раз увеличить время", m => m.Checkpoint2TimeMultiplier),
            ("КТ2 Кол-во импульсов за 60 с", m => m.Checkpoint2PulseCount),
            ("Предел отн. погрешности, % ( Qt2-Qt1)", m => m.RelativeErrorQt2Qt1),
            ("Котрольная точка 3", m => m.Checkpoint3),
            ("КТ3 Требуемое время (для 500 импульсов, не менее 60 с)", m => m.Checkpoint3RequiredTime),
            ("КТ3 Во сколько раз увеличить время", m => m.Checkpoint3TimeMultiplier),
            ("КТ3 Кол-во импульсов за 60 с", m => m.Checkpoint3PulseCount),
            ("Предел отн. погрешности, % ( Qt1-Qmax)", m => m.RelativeErrorQt1Qmax),
            ("Котрольная точка 4", m => m.Checkpoint4),
            ("КТ4 Требуемое время (для 500 импульсов, не менее 60 с)", m => m.Checkpoint4RequiredTime),
            ("КТ4 Во сколько раз увеличить время", m => m.Checkpoint4TimeMultiplier),
            ("КТ4 Кол-во импульсов за 60 с", m => m.Checkpoint4PulseCount),
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
                    double.TryParse(_meters[i].MinPulseCount, NumberStyles.Any, CultureInfo.InvariantCulture, out var required)
                    &&
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
