using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms.Verifier
{
    public partial class MetersSetupForm : Form
    {
        private readonly MeterTypeService _meterTypeService = null!;
        private readonly ManufacturerService _manufacturerService = null!;
        private bool _updating;
        private readonly Dictionary<ComboBox, CancellationTokenSource> _searchTokens = new();
        private readonly Dictionary<ComboBox, string> _typedTexts = new();
        public MetersSetupForm()
        {
            InitializeComponent();
        }

        public MetersSetupForm(MeterTypeService meterTypeService, ManufacturerService manufacturerService) : this()
        {
            _meterTypeService = meterTypeService;
            _manufacturerService = manufacturerService;
        }

        private async void MetersSetupForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            AddDateFields();

            Rashodomer1_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer2_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer3_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer4_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer5_CB_CheckedChanged(null, EventArgs.Empty);
            Rashodomer6_CB_CheckedChanged(null, EventArgs.Empty);

            await _meterTypeService.GetAllAsync(string.Empty, 10);
            await _manufacturerService.GetAllAsync(string.Empty, 10);
        }

        private void AddDateFields()
        {
            int offset = AddDateField(Rashodomer1_GB, GosReestr, Flow1_GosReestr_CB, label3, Flow1_Modification_CB,
                new Control[] { label4, Flow1_ZavodskNomer_TB, label5, Flow1_Diameter_CB, label6, Flow1_WeightImpulse_TB, label7, Flow1_Document_CB });
            ShiftGroupBoxes(new[] { Rashodomer2_GB, Rashodomer3_GB, Rashodomer4_GB, Rashodomer5_GB, Rashodomer6_GB }, offset);

            offset = AddDateField(Rashodomer2_GB, label12, Flow2_GosReestr_CB, label16, Flow2_Modification_CB,
                new Control[] { label17, Flow2_ZavodskNomer_TB, label15, Flow2_Diameter_CB, label13, Flow2_WeightImpulse_TB, label11, Flow2_Document_CB });
            ShiftGroupBoxes(new[] { Rashodomer3_GB, Rashodomer4_GB, Rashodomer5_GB, Rashodomer6_GB }, offset);

            offset = AddDateField(Rashodomer3_GB, label19, Flow3_GosReestr_CB, label23, Flow3_Modification_CB,
                new Control[] { label24, Flow3_ZavodskNomer_TB, label22, Flow3_Diameter_CB, label20, Flow3_WeightImpulse_TB, label18, Flow3_Document_CB });
            ShiftGroupBoxes(new[] { Rashodomer4_GB, Rashodomer5_GB, Rashodomer6_GB }, offset);

            offset = AddDateField(Rashodomer4_GB, label27, Flow4_GosReestr_CB, label31, Flow4_Modification_CB,
                new Control[] { label32, Flow4_ZavodskNomer_TB, label30, Flow4_Diameter_CB, label28, Flow4_WeightImpulse_TB, label26, Flow4_Document_CB });
            ShiftGroupBoxes(new[] { Rashodomer5_GB, Rashodomer6_GB }, offset);

            offset = AddDateField(Rashodomer5_GB, label35, Flow5_GosReestr_CB, label39, Flow5_Modification_CB,
                new Control[] { label40, Flow5_ZavodskNomer_TB, label38, Flow5_Diameter_CB, label36, Flow5_WeightImpulse_TB, label34, Flow5_Document_CB });
            ShiftGroupBoxes(new[] { Rashodomer6_GB }, offset);

            AddDateField(Rashodomer6_GB, label43, Flow6_GosReestr_CB, label47, Flow6_Modification_CB,
                new Control[] { label48, Flow6_ZavodskNomer_TB, label46, Flow6_Diameter_CB, label44, Flow6_WeightImpulse_TB, label42, Flow6_Document_CB });
        }

        private int AddDateField(GroupBox groupBox, Label manufacturerLabel, ComboBox manufacturerCombo,
            Label modificationLabel, ComboBox modificationCombo, Control[] controlsToShift)
        {
            var dateLabel = new Label
            {
                AutoSize = true,
                Text = "Дата выпуска",
                Location = new Point(manufacturerLabel.Left, manufacturerCombo.Bottom + 10)
            };

            var datePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(manufacturerCombo.Left, manufacturerCombo.Bottom + 8),
                Size = manufacturerCombo.Size
            };

            groupBox.Controls.Add(dateLabel);
            groupBox.Controls.Add(datePicker);

            int offset = datePicker.Height + 8;
            modificationLabel.Top += offset;
            modificationCombo.Top += offset;

            foreach (var ctrl in controlsToShift)
                ctrl.Top += offset;

            groupBox.Height += offset;
            return offset;
        }

        private static void ShiftGroupBoxes(GroupBox[] groups, int offset)
        {
            foreach (var gb in groups)
                gb.Top += offset;
        }

        private void Flow1_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow2_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow3_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow4_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow5_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Flow6_Name_SI_CB_SelectedIndexChanged(object sender, EventArgs e) { }

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
            _typedTexts[combo] = search;

            if (dropDown)
            {
                combo.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                Cursor.Show();
            }

            _updating = false;
        }

        private async Task PopulateManufacturersAsync(ComboBox combo, string search, int? limit = null, bool dropDown = false)
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
                if (newIndex < 0) newIndex = count - 1;
                if (newIndex >= count) newIndex = 0;
                combo.SelectedIndex = newIndex;

                BeginInvoke(new Action(() =>
                {
                    _updating = true;
                    combo.Text = text;
                    combo.SelectionStart = text.Length;
                    combo.SelectionLength = 0;
                    _updating = false;
                }));
            }
        }

        private async void MeterTypeCB_KeyUp(object? sender, KeyEventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
                return;

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
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
            catch (TaskCanceledException)
            {
            }
        }

        private async void MeterTypeCB_Click(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo)
            {
                combo.SelectionLength = 0;
                await PopulateMeterTypesAsync(combo, combo.Text, combo.Text.Length > 0 ? 20 : 10, dropDown: true);
            }
        }
        private async void ManufacturerCB_KeyUp(object? sender, KeyEventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
                return;

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
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
            catch (TaskCanceledException)
            {
            }
        }

        private async void ManufacturerCB_Click(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo)
            {
                combo.SelectionLength = 0;
                await PopulateManufacturersAsync(combo, combo.Text, combo.Text.Length > 0 ? 20 : 10, dropDown: true);
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
