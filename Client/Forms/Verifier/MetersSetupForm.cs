using System;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms.Verifier
{
    public partial class MetersSetupForm : Form
    {
        public MetersSetupForm()
        {
            InitializeComponent();
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
        private void button2_Click(object sender, EventArgs e) { }

        private void Rashodomer1_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer1_GB.Enabled = Rashodomer1_CB.Checked;
            Rashodomer1_CB.Text = Rashodomer1_CB.Checked ? "Выключить" : "Включить";
        }

        private void Rashodomer2_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer2_GB.Enabled = Rashodomer2_CB.Checked;
            Rashodomer2_CB.Text = Rashodomer2_CB.Checked ? "Выключить" : "Включить";
        }

        private void Rashodomer3_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer3_GB.Enabled = Rashodomer3_CB.Checked;
            Rashodomer3_CB.Text = Rashodomer3_CB.Checked ? "Выключить" : "Включить";
        }

        private void Rashodomer6_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer6_GB.Enabled = Rashodomer6_CB.Checked;
            Rashodomer6_CB.Text = Rashodomer6_CB.Checked ? "Выключить" : "Включить";
        }

        private void Rashodomer5_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer5_GB.Enabled = Rashodomer5_CB.Checked;
            Rashodomer5_CB.Text = Rashodomer5_CB.Checked ? "Выключить" : "Включить";
        }

        private void Rashodomer4_CB_CheckedChanged(object sender, EventArgs e)
        {
            Rashodomer4_GB.Enabled = Rashodomer4_CB.Checked;
            Rashodomer4_CB.Text = Rashodomer4_CB.Checked ? "Выключить" : "Включить";
        }
        private void groupBox6_Enter(object sender, EventArgs e)
        {
            // TODO: добавить логику обработки при необходимости
        }
    }
}
