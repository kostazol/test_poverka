using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using PoverkaWinForms.Domain;
using PoverkaWinForms.Services;

namespace PoverkaWinForms
{
    public partial class MainForm : Form
    {
        private readonly BindingList<TestRun> _runs = new BindingList<TestRun>();
        private readonly IRunRepository _repo;
        private readonly string _reportsDir;

        public MainForm(IRunRepository repo)
        {
            InitializeComponent();
            _repo = repo;
            _reportsDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Poverka", "Reports");

            var loaded = _repo.GetAll();
            foreach (var r in loaded) _runs.Add(r);

            gridResults.AutoGenerateColumns = false;
            gridResults.DataSource = _runs;

            txtSerial.Text = "0001";
            txtModel.Text = "DUT-100";
            numDiameter.Value = 50;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var run = new TestRun
            {
                Meter = new Meter
                {
                    Serial = txtSerial.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    DiameterMm = (double)numDiameter.Value
                },
                VolumeLiters = (double)numVolume.Value,
                TimeSeconds = (double)numTime.Value,
                IndicatedFlow = (double)numIndicated.Value,
                TemperatureC = (double)numTemp.Value,
                PressureKPa = (double)numPressure.Value
            };

            run.ActualFlow = Calculator.CalculateActualFlow(run.VolumeLiters, run.TimeSeconds, run.TemperatureC);
            run.ErrorPercent = Calculator.CalculateErrorPercent(run.IndicatedFlow, run.ActualFlow);

            _runs.Add(run);
            _repo.Add(run);

            MessageBox.Show($"Готово.\nДействительный поток: {run.ActualFlow:0.###} л/с\nПогрешность: {run.ErrorPercent:0.###} %",
                "Расчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var current = gridResults.CurrentRow != null
                ? gridResults.CurrentRow.DataBoundItem as TestRun
                : null;
            if (current == null)
            {
                MessageBox.Show("Выберите запись в таблице результатов.", "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var path = ReportGenerator.SaveRtfTo(_reportsDir, current);
            linkLastReport.Text = path;
            linkLastReport.Visible = true;
        }

        private void linkLastReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (File.Exists(linkLastReport.Text))
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = linkLastReport.Text, UseShellExecute = true });
            }
            catch { }
        }

        private void btnMetersSetup_Click(object sender, EventArgs e)
        {
            using (var dlg = new MetersSetupForm())
            {
                dlg.ShowDialog(this);
            }
        }
    }
}
