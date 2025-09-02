using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms.Verifier
{
    public partial class VerificationProgramForm : Form
    {
        private readonly IReadOnlyList<FlowMeterInfo> _meters;

        public VerificationProgramForm()
        {
            InitializeComponent();
            _meters = Array.Empty<FlowMeterInfo>();
        }

        public VerificationProgramForm(IReadOnlyList<FlowMeterInfo> meters) : this()
        {
            _meters = meters;
        }

        private void VerificationProgramFormLoad(object? sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            string[] parameters =
            {
                "Тип",
                "Изготовитель",
                "Модификация",
                "Номер госреестра СИ"
            };

            foreach (var parameter in parameters)
            {
                int rowIndex = ProgramDataGridView.Rows.Add();
                ProgramDataGridView.Rows[rowIndex].Cells[0].Value = parameter;
            }

            for (int i = 0; i < _meters.Count && i < 6; i++)
            {
                var info = _meters[i];
                ProgramDataGridView.Rows[0].Cells[i + 1].Value = info.Type;
                ProgramDataGridView.Rows[1].Cells[i + 1].Value = info.Manufacturer;
                ProgramDataGridView.Rows[2].Cells[i + 1].Value = info.Modification;
                ProgramDataGridView.Rows[3].Cells[i + 1].Value = info.RegistrationNumber;
            }
        }
    }
}
