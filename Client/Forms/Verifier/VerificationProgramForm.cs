using System;
using System.Collections.Generic;
using System.Linq;
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

        var meterRows = _meters.Select(m => m.Rows.ToList()).ToList();
        if (meterRows.Count == 0)
        {
            return;
        }

        int rowCount = meterRows[0].Count;
        for (int row = 0; row < rowCount; row++)
        {
            int rowIndex = ProgramDataGridView.Rows.Add();
            ProgramDataGridView.Rows[rowIndex].Cells[0].Value = meterRows[0][row].Label;

            for (int i = 0; i < meterRows.Count && i < 6; i++)
            {
                ProgramDataGridView.Rows[rowIndex].Cells[i + 1].Value = meterRows[i][row].Value;
            }
        }
    }
}
