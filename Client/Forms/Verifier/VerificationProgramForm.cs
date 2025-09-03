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

    private void VerificationProgramForm_Load(object? sender, EventArgs e)
    {
        if (DesignMode)
        {
            return;
        }

        var meterRows = _meters.Select(m => m.Rows.ToList()).ToList();
        if (meterRows.Count == 0)
            return;

        for (int rowIndex = 0; rowIndex < meterRows[0].Count; rowIndex++)
        {
            int gridRow = ProgramDataGridView.Rows.Add();
            ProgramDataGridView.Rows[gridRow].Cells[0].Value = meterRows[0][rowIndex].Label;

            for (int i = 0; i < meterRows.Count && i < 6; i++)
            {
                ProgramDataGridView.Rows[gridRow].Cells[i + 1].Value = meterRows[i][rowIndex].Value;
            }
        }
    }
}
