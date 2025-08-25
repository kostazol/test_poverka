using System;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms.Verifier
{
    public partial class MetersSetupForm : Form
    {
        public MetersSetupForm()
        {
            InitializeComponent();

            Rashodomer1_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer2_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer3_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer4_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer5_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer6_CB_CheckedChanged(null, EventArgs.Empty);
        }

        private void MetersSetupForm_Load(object sender, EventArgs e)
        {
            // TODO: добавить логику загрузки при необходимости
        }

        private void Flow1_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void GosReestrCB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow2_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow3_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow4_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow5_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow6_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void Next_B_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

        private void Rashodomer1_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer1_GB, Rashodomer1_CB, label8);
        }

        private void Rashodomer2_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer2_GB, Rashodomer2_CB, label10);
        }

        private void Rashodomer3_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer3_GB, Rashodomer3_CB, label9);
        }

        private void Rashodomer6_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer6_GB, Rashodomer6_CB, label41);
        }

        private void Rashodomer5_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer5_GB, Rashodomer5_CB, label33);
        }

        private void Rashodomer4_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer4_GB, Rashodomer4_CB, label25);
        }
        private void groupBox6_Enter(object sender, EventArgs e)
        {
            // TODO: добавить логику обработки при необходимости
        }

        private static void ToggleGroupControls(GroupBox groupBox, CheckBox checkBox, Label caption)
        {
            bool visible = checkBox.Checked;
            checkBox.Text = visible ? "Выключить" : "Включить";

            foreach (Control control in groupBox.Controls)
            {
                if (control != caption && control != checkBox)
                {
                    control.Visible = visible;
                }
            }
        }
    }
}
