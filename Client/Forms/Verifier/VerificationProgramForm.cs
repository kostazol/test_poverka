using System;
using System.Collections.Generic;
using System.Drawing;
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
            ("Время поверки, с", m => m.MeasurementDurationInSeconds),
            ("Qmax", m => m.Qmax),
            ("Методика поверки", m => m.VerificationMethodology),
            ("Кол-во изм-й в точке", m => m.NumberOfMeasurements),
            ("Измененное время поверки", _ => string.Empty),
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

            bool editable = row.Label.StartsWith("Измененн");
            for (int i = 0; i < _meters.Count && i < 6; i++)
            {
                var cell = dataGridViewRow.Cells[i + 1];
                cell.Value = row.Get(_meters[i]);
                cell.ReadOnly = !editable;
                if (!editable)
                {
                    cell.Style.BackColor = Color.LightGray;
                }
            }
            for (int i = _meters.Count; i < 6; i++)
            {
                var cell = dataGridViewRow.Cells[i + 1];
                cell.ReadOnly = !editable;
                if (!editable)
                {
                    cell.Style.BackColor = Color.LightGray;
                }
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
