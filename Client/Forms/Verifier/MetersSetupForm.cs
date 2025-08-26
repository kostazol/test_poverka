using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms.Verifier
{
    public partial class MetersSetupForm : Form
    {
        private readonly MeterTypeService _meterTypeService = null!;
        private bool _updating;

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

    public MetersSetupForm(MeterTypeService meterTypeService) : this()
    {
        _meterTypeService = meterTypeService;
    }

        private async void MetersSetupForm_Load(object sender, EventArgs e)
        {
            await _meterTypeService.GetAllAsync(string.Empty, 10);
        }

        private void Flow1_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private async Task PopulateMeterTypesAsync(ComboBox combo, string search, int? limit = null, bool dropDown = false)
        {
            var items = await _meterTypeService.GetAllAsync(search, limit);

            var selStart = combo.SelectionStart;
            _updating = true;
            combo.BeginUpdate();
            combo.DataSource = items;
            combo.DisplayMember = nameof(MeterTypeDto.Type);
            combo.ValueMember = nameof(MeterTypeDto.Id);
            combo.SelectedIndex = -1;
            combo.Text = search;
            combo.SelectionStart = selStart;
            combo.SelectionLength = 0;
            combo.EndUpdate();
            _updating = false;

            if (dropDown)
                combo.DroppedDown = true;
        }

        private async void MeterTypeCB_TextChanged(object? sender, EventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
                return;

            if (combo.SelectedIndex >= 0)
            {
                combo.DroppedDown = false;
                return;
            }

            await PopulateMeterTypesAsync(combo, combo.Text, limit: 20, dropDown: true);
        }
        private void GosReestrCB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow2_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow3_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow4_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow5_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Flow6_GosReestr_CB_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void Next_B_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

        private async void Rashodomer1_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer1_GB, Rashodomer1_CB, label8);
            if (Rashodomer1_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow1_Name_SI_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer2_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer2_GB, Rashodomer2_CB, label10);
            if (Rashodomer2_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow2_Name_SI_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer3_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer3_GB, Rashodomer3_CB, label9);
            if (Rashodomer3_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow3_Name_SI_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer6_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer6_GB, Rashodomer6_CB, label41);
            if (Rashodomer6_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow6_Name_SI_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer5_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer5_GB, Rashodomer5_CB, label33);
            if (Rashodomer5_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow5_Name_SI_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer4_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer4_GB, Rashodomer4_CB, label25);
            if (Rashodomer4_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow4_Name_SI_CB, string.Empty, 10);
            }
        }
        private void groupBox6_Enter(object sender, EventArgs e)
        {
            // TODO: добавить логику обработки при необходимости
        }

        private static void ToggleGroupControls(GroupBox groupBox, CheckBox checkBox, Label caption)
        {
            bool visible = checkBox.Checked;

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
