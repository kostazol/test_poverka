using System.Windows.Forms;

namespace PoverkaWinForms
{
    partial class MainForm
    {
        private TabControl tabs;
        private TabPage tabCalib;
        private TabPage tabResults;
        private GroupBox grpMeter;
        private Label lblSerial;
        private TextBox txtSerial;
        private Label lblModel;
        private TextBox txtModel;
        private Label lblDiameter;
        private NumericUpDown numDiameter;

        private GroupBox grpRun;
        private Label lblVolume;
        private NumericUpDown numVolume;
        private Label lblTime;
        private NumericUpDown numTime;
        private Label lblIndicated;
        private NumericUpDown numIndicated;
        private Label lblTemp;
        private NumericUpDown numTemp;
        private Label lblPressure;
        private NumericUpDown numPressure;
        private Button btnCalculate;
        private Button btnMetersSetup;

        private DataGridView gridResults;
        private Button btnGenerateReport;
        private LinkLabel linkLastReport;

        private void InitializeComponent()
        {
            tabs = new TabControl();
            tabCalib = new TabPage();
            grpMeter = new GroupBox();
            lblSerial = new Label();
            txtSerial = new TextBox();
            lblModel = new Label();
            txtModel = new TextBox();
            lblDiameter = new Label();
            numDiameter = new NumericUpDown();
            grpRun = new GroupBox();
            lblVolume = new Label();
            numVolume = new NumericUpDown();
            lblTime = new Label();
            numTime = new NumericUpDown();
            lblIndicated = new Label();
            numIndicated = new NumericUpDown();
            lblTemp = new Label();
            numTemp = new NumericUpDown();
            lblPressure = new Label();
            numPressure = new NumericUpDown();
            btnCalculate = new Button();
            btnMetersSetup = new Button();
            tabResults = new TabPage();
            gridResults = new DataGridView();
            btnGenerateReport = new Button();
            linkLastReport = new LinkLabel();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            tabs.SuspendLayout();
            tabCalib.SuspendLayout();
            grpMeter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiameter).BeginInit();
            grpRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIndicated).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTemp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPressure).BeginInit();
            tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
            SuspendLayout();
            // 
            // tabs
            // 
            tabs.Controls.Add(tabCalib);
            tabs.Controls.Add(tabResults);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 0);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(800, 450);
            tabs.TabIndex = 0;
            // 
            // tabCalib
            // 
            tabCalib.Controls.Add(btnMetersSetup);
            tabCalib.Controls.Add(grpMeter);
            tabCalib.Controls.Add(grpRun);
            tabCalib.Location = new Point(4, 24);
            tabCalib.Name = "tabCalib";
            tabCalib.Padding = new Padding(10);
            tabCalib.Size = new Size(792, 422);
            tabCalib.TabIndex = 0;
            tabCalib.Text = "Калибровка";
            // 
            // grpMeter
            // 
            grpMeter.Controls.Add(lblSerial);
            grpMeter.Controls.Add(txtSerial);
            grpMeter.Controls.Add(lblModel);
            grpMeter.Controls.Add(txtModel);
            grpMeter.Controls.Add(lblDiameter);
            grpMeter.Controls.Add(numDiameter);
            grpMeter.Location = new Point(10, 10);
            grpMeter.Name = "grpMeter";
            grpMeter.Size = new Size(500, 120);
            grpMeter.TabIndex = 0;
            grpMeter.TabStop = false;
            grpMeter.Text = "Расходомер";
            // 
            // lblSerial
            // 
            lblSerial.Location = new Point(10, 25);
            lblSerial.Name = "lblSerial";
            lblSerial.Size = new Size(100, 24);
            lblSerial.TabIndex = 0;
            lblSerial.Text = "Серийный №";
            // 
            // txtSerial
            // 
            txtSerial.Location = new Point(120, 22);
            txtSerial.Name = "txtSerial";
            txtSerial.Size = new Size(120, 23);
            txtSerial.TabIndex = 1;
            // 
            // lblModel
            // 
            lblModel.Location = new Point(260, 25);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(70, 24);
            lblModel.TabIndex = 2;
            lblModel.Text = "Модель";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(330, 22);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(150, 23);
            txtModel.TabIndex = 3;
            // 
            // lblDiameter
            // 
            lblDiameter.Location = new Point(10, 70);
            lblDiameter.Name = "lblDiameter";
            lblDiameter.Size = new Size(100, 24);
            lblDiameter.TabIndex = 4;
            lblDiameter.Text = "Диаметр, мм";
            // 
            // numDiameter
            // 
            numDiameter.Location = new Point(120, 68);
            numDiameter.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numDiameter.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            numDiameter.Name = "numDiameter";
            numDiameter.Size = new Size(120, 23);
            numDiameter.TabIndex = 5;
            numDiameter.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // grpRun
            // 
            grpRun.Controls.Add(lblVolume);
            grpRun.Controls.Add(numVolume);
            grpRun.Controls.Add(lblTime);
            grpRun.Controls.Add(numTime);
            grpRun.Controls.Add(lblIndicated);
            grpRun.Controls.Add(numIndicated);
            grpRun.Controls.Add(lblTemp);
            grpRun.Controls.Add(numTemp);
            grpRun.Controls.Add(lblPressure);
            grpRun.Controls.Add(numPressure);
            grpRun.Controls.Add(btnCalculate);
            grpRun.Location = new Point(10, 140);
            grpRun.Name = "grpRun";
            grpRun.Size = new Size(500, 200);
            grpRun.TabIndex = 1;
            grpRun.TabStop = false;
            grpRun.Text = "Пролив";
            // 
            // lblVolume
            // 
            lblVolume.Location = new Point(10, 30);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(100, 24);
            lblVolume.TabIndex = 0;
            lblVolume.Text = "Объём, л";
            // 
            // numVolume
            // 
            numVolume.DecimalPlaces = 3;
            numVolume.Location = new Point(120, 28);
            numVolume.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(120, 23);
            numVolume.TabIndex = 1;
            // 
            // lblTime
            // 
            lblTime.Location = new Point(260, 30);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(100, 24);
            lblTime.TabIndex = 2;
            lblTime.Text = "Время, с";
            // 
            // numTime
            // 
            numTime.DecimalPlaces = 3;
            numTime.Location = new Point(330, 28);
            numTime.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numTime.Name = "numTime";
            numTime.Size = new Size(120, 23);
            numTime.TabIndex = 3;
            // 
            // lblIndicated
            // 
            lblIndicated.Location = new Point(10, 70);
            lblIndicated.Name = "lblIndicated";
            lblIndicated.Size = new Size(150, 24);
            lblIndicated.TabIndex = 4;
            lblIndicated.Text = "Поток по прибору, л/с";
            // 
            // numIndicated
            // 
            numIndicated.DecimalPlaces = 3;
            numIndicated.Location = new Point(170, 68);
            numIndicated.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numIndicated.Name = "numIndicated";
            numIndicated.Size = new Size(120, 23);
            numIndicated.TabIndex = 5;
            // 
            // lblTemp
            // 
            lblTemp.Location = new Point(310, 70);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(120, 24);
            lblTemp.TabIndex = 6;
            lblTemp.Text = "Температура, °C";
            // 
            // numTemp
            // 
            numTemp.DecimalPlaces = 1;
            numTemp.Location = new Point(430, 68);
            numTemp.Minimum = new decimal(new int[] { 20, 0, 0, int.MinValue });
            numTemp.Name = "numTemp";
            numTemp.Size = new Size(60, 23);
            numTemp.TabIndex = 7;
            // 
            // lblPressure
            // 
            lblPressure.Location = new Point(10, 110);
            lblPressure.Name = "lblPressure";
            lblPressure.Size = new Size(120, 24);
            lblPressure.TabIndex = 8;
            lblPressure.Text = "Давление, кПа";
            // 
            // numPressure
            // 
            numPressure.DecimalPlaces = 1;
            numPressure.Location = new Point(170, 108);
            numPressure.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPressure.Name = "numPressure";
            numPressure.Size = new Size(120, 23);
            numPressure.TabIndex = 9;
            // 
            // btnCalculate
            //
            btnCalculate.Location = new Point(310, 105);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(180, 30);
            btnCalculate.TabIndex = 10;
            btnCalculate.Text = "Рассчитать и сохранить";
            btnCalculate.Click += btnCalculate_Click;
            //
            // btnMetersSetup
            //
            btnMetersSetup.Location = new Point(520, 10);
            btnMetersSetup.Name = "btnMetersSetup";
            btnMetersSetup.Size = new Size(250, 30);
            btnMetersSetup.TabIndex = 2;
            btnMetersSetup.Text = "Настройка преобразователей...";
            btnMetersSetup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMetersSetup.Click += btnMetersSetup_Click;
            //
            // tabResults
            //
            tabResults.Controls.Add(gridResults);
            tabResults.Controls.Add(btnGenerateReport);
            tabResults.Controls.Add(linkLastReport);
            tabResults.Location = new Point(4, 24);
            tabResults.Name = "tabResults";
            tabResults.Padding = new Padding(10);
            tabResults.Size = new Size(792, 422);
            tabResults.TabIndex = 1;
            tabResults.Text = "Результаты";
            // 
            // gridResults
            // 
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridResults.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            gridResults.Location = new Point(10, 10);
            gridResults.Name = "gridResults";
            gridResults.ReadOnly = true;
            gridResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridResults.Size = new Size(1352, 682);
            gridResults.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGenerateReport.Location = new Point(10, 702);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(200, 30);
            btnGenerateReport.TabIndex = 1;
            btnGenerateReport.Text = "Сгенерировать отчёт";
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // linkLastReport
            // 
            linkLastReport.Location = new Point(220, 385);
            linkLastReport.Name = "linkLastReport";
            linkLastReport.Size = new Size(550, 20);
            linkLastReport.TabIndex = 2;
            linkLastReport.TabStop = true;
            linkLastReport.Text = "отчёт";
            linkLastReport.Visible = false;
            linkLastReport.LinkClicked += linkLastReport_LinkClicked;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(tabs);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Поверка расходомеров — Проливная (демо, .NET 9 WinForms)";
            tabs.ResumeLayout(false);
            tabCalib.ResumeLayout(false);
            grpMeter.ResumeLayout(false);
            grpMeter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiameter).EndInit();
            grpRun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIndicated).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTemp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPressure).EndInit();
            tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridResults).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}
