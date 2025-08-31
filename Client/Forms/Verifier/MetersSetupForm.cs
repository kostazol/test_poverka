using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms.Verifier
{
    public partial class MetersSetupForm : Form
    {
        private readonly MeterTypeService _meterTypeService;
        private readonly ManufacturerService _manufacturerService;
        private readonly ModificationService _modificationService;
        private bool _updating;
        private readonly Dictionary<ComboBox, CancellationTokenSource> _searchTokens = new();
        private readonly Dictionary<ComboBox, string> _typedTexts = new();

        public MetersSetupForm(
            MeterTypeService meterTypeService,
            ManufacturerService manufacturerService,
            ModificationService modificationService
        )
        {
            _meterTypeService = meterTypeService;
            _manufacturerService = manufacturerService;
            _modificationService = modificationService;
            InitializeComponent();
        }

        private async void MetersSetupForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            Rashodomer1_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer2_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer3_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer4_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer5_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer6_CB_CheckedChanged(null, EventArgs.Empty);

            await _meterTypeService.GetAllAsync(string.Empty, 10);
            await _manufacturerService.GetAllAsync(string.Empty, 10);
        }

        private void Flow1_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow2_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow3_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow4_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow5_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow6_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private async Task PopulateMeterTypesAsync(
            ComboBox combo,
            string search,
            int? limit = null,
            bool dropDown = false
        )
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
            _typedTexts[combo] = search;

            if (dropDown)
            {
                combo.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                Cursor.Show();
            }

            _updating = false;
        }

        private async Task PopulateManufacturersAsync(
            ComboBox combo,
            string search,
            int? limit = null,
            bool dropDown = false
        )
        {
            var items = await _manufacturerService.GetAllAsync(search, limit);

            var selStart = combo.SelectionStart;
            _updating = true;
            combo.BeginUpdate();
            combo.DataSource = items;
            combo.DisplayMember = nameof(ManufacturerDto.Name);
            combo.ValueMember = nameof(ManufacturerDto.Id);
            combo.SelectedIndex = -1;
            combo.Text = search;
            combo.SelectionStart = selStart;
            combo.SelectionLength = 0;
            combo.EndUpdate();
            _typedTexts[combo] = search;

            if (dropDown)
            {
                combo.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                Cursor.Show();
            }

            _updating = false;
        }

        private async Task PopulateModificationsAsync(
            ComboBox modificationCombo,
            ComboBox meterTypeCombo,
            ComboBox manufacturerCombo,
            DateTimePicker datePicker
        )
        {
            if (meterTypeCombo.SelectedValue is not int meterTypeId)
                return;
            if (manufacturerCombo.SelectedValue is not int manufacturerId)
                return;

            var manufactureDate = DateOnly.FromDateTime(datePicker.Value);
            var items = await _modificationService.GetAllAsync(meterTypeId, manufacturerId, manufactureDate);

            _updating = true;
            modificationCombo.BeginUpdate();
            modificationCombo.DataSource = items;
            modificationCombo.DisplayMember = nameof(ModificationDto.Name);
            modificationCombo.ValueMember = nameof(ModificationDto.Id);
            modificationCombo.SelectedIndex = -1;
            modificationCombo.EndUpdate();
            _updating = false;
        }

        private void MeterTypeCB_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not ComboBox combo)
                return;

            if (_searchTokens.TryGetValue(combo, out var prev))
                prev.Cancel();

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (combo.SelectedIndex >= 0)
                {
                    _updating = true;
                    combo.Text = combo.GetItemText(combo.SelectedItem);
                    combo.SelectionStart = combo.Text.Length;
                    combo.SelectionLength = 0;
                    _typedTexts[combo] = combo.Text;
                    _updating = false;
                }
                combo.DroppedDown = false;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = true;

                if (!_typedTexts.TryGetValue(combo, out var text))
                    text = combo.Text;

                if (!combo.DroppedDown)
                {
                    combo.DroppedDown = true;
                    combo.SelectedIndex = -1;
                }

                int direction = e.KeyCode == Keys.Down ? 1 : -1;
                int count = combo.Items.Count;
                if (count == 0)
                    return;
                int newIndex = combo.SelectedIndex + direction;
                if (newIndex < 0)
                    newIndex = count - 1;
                if (newIndex >= count)
                    newIndex = 0;
                combo.SelectedIndex = newIndex;

                BeginInvoke(
                    new Action(() =>
                    {
                        _updating = true;
                        combo.Text = text;
                        combo.SelectionStart = text.Length;
                        combo.SelectionLength = 0;
                        _updating = false;
                    })
                );
            }
        }

        private async void MeterTypeCB_KeyUp(object? sender, KeyEventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
                return;

            if (
                e.KeyCode == Keys.Enter
                || e.KeyCode == Keys.Up
                || e.KeyCode == Keys.Down
                || e.KeyCode == Keys.Left
                || e.KeyCode == Keys.Right
            )
                return;

            var keyChar = (char)e.KeyValue;
            if (!char.IsLetter(keyChar) && e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
                return;

            _typedTexts[combo] = combo.Text;

            if (_searchTokens.TryGetValue(combo, out var prev))
                prev.Cancel();

            var cts = new CancellationTokenSource();
            _searchTokens[combo] = cts;

            try
            {
                await Task.Delay(300, cts.Token);
                await PopulateMeterTypesAsync(combo, combo.Text, limit: 20, dropDown: true);
            }
            catch (TaskCanceledException) { }
        }

        private async void MeterTypeCB_Click(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo)
            {
                combo.SelectionLength = 0;
                await PopulateMeterTypesAsync(
                    combo,
                    combo.Text,
                    combo.Text.Length > 0 ? 20 : 10,
                    dropDown: true
                );
            }
        }

        private async void ManufacturerCB_KeyUp(object? sender, KeyEventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
                return;

            if (
                e.KeyCode == Keys.Enter
                || e.KeyCode == Keys.Up
                || e.KeyCode == Keys.Down
                || e.KeyCode == Keys.Left
                || e.KeyCode == Keys.Right
            )
                return;

            var keyChar = (char)e.KeyValue;
            if (!char.IsLetter(keyChar) && e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
                return;

            _typedTexts[combo] = combo.Text;

            if (_searchTokens.TryGetValue(combo, out var prev))
                prev.Cancel();

            var cts = new CancellationTokenSource();
            _searchTokens[combo] = cts;

            try
            {
                await Task.Delay(300, cts.Token);
                await PopulateManufacturersAsync(combo, combo.Text, limit: 20, dropDown: true);
            }
            catch (TaskCanceledException) { }
        }

        private async void ManufacturerCB_Click(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo)
            {
                combo.SelectionLength = 0;
                await PopulateManufacturersAsync(
                    combo,
                    combo.Text,
                    combo.Text.Length > 0 ? 20 : 10,
                    dropDown: true
                );
            }
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

        private async void Flow1_Modification_CB_Click(object? sender, EventArgs e) =>
            await PopulateModificationsAsync(
                Flow1_Modification_CB,
                Flow1_Name_SI_CB,
                Flow1_GosReestr_CB,
                Flow1_ManufactureDate_DTP
            );

        private async void Flow2_Modification_CB_Click(object? sender, EventArgs e) =>
            await PopulateModificationsAsync(
                Flow2_Modification_CB,
                Flow2_Name_SI_CB,
                Flow2_GosReestr_CB,
                Flow2_ManufactureDate_DTP
            );

        private async void Flow3_Modification_CB_Click(object? sender, EventArgs e) =>
            await PopulateModificationsAsync(
                Flow3_Modification_CB,
                Flow3_Name_SI_CB,
                Flow3_GosReestr_CB,
                Flow3_ManufactureDate_DTP
            );

        private async void Flow4_Modification_CB_Click(object? sender, EventArgs e) =>
            await PopulateModificationsAsync(
                Flow4_Modification_CB,
                Flow4_Name_SI_CB,
                Flow4_GosReestr_CB,
                Flow4_ManufactureDate_DTP
            );

        private async void Flow5_Modification_CB_Click(object? sender, EventArgs e) =>
            await PopulateModificationsAsync(
                Flow5_Modification_CB,
                Flow5_Name_SI_CB,
                Flow5_GosReestr_CB,
                Flow5_ManufactureDate_DTP
            );

        private async void Flow6_Modification_CB_Click(object? sender, EventArgs e) =>
            await PopulateModificationsAsync(
                Flow6_Modification_CB,
                Flow6_Name_SI_CB,
                Flow6_GosReestr_CB,
                Flow6_ManufactureDate_DTP
            );

        private async void Rashodomer1_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer1_GB, Rashodomer1_CB, label8);
            if (Rashodomer1_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow1_Name_SI_CB, string.Empty, 10);
                await PopulateManufacturersAsync(Flow1_GosReestr_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer2_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer2_GB, Rashodomer2_CB, label10);
            if (Rashodomer2_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow2_Name_SI_CB, string.Empty, 10);
                await PopulateManufacturersAsync(Flow2_GosReestr_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer3_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer3_GB, Rashodomer3_CB, label9);
            if (Rashodomer3_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow3_Name_SI_CB, string.Empty, 10);
                await PopulateManufacturersAsync(Flow3_GosReestr_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer6_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer6_GB, Rashodomer6_CB, label41);
            if (Rashodomer6_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow6_Name_SI_CB, string.Empty, 10);
                await PopulateManufacturersAsync(Flow6_GosReestr_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer5_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer5_GB, Rashodomer5_CB, label33);
            if (Rashodomer5_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow5_Name_SI_CB, string.Empty, 10);
                await PopulateManufacturersAsync(Flow5_GosReestr_CB, string.Empty, 10);
            }
        }

        private async void Rashodomer4_CB_CheckedChanged(object? sender, EventArgs e)
        {
            ToggleGroupControls(Rashodomer4_GB, Rashodomer4_CB, label25);
            if (Rashodomer4_CB.Checked)
            {
                await PopulateMeterTypesAsync(Flow4_Name_SI_CB, string.Empty, 10);
                await PopulateManufacturersAsync(Flow4_GosReestr_CB, string.Empty, 10);
            }
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
