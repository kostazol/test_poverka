using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly Dictionary<ComboBox, List<ModificationDto>> _modifications = new();
        private readonly Dictionary<ComboBox, string> _previousTexts = new();
        private readonly List<FlowMeterSection> _flowMeters = new();

        public MetersSetupForm(MeterTypeService meterTypeService, ManufacturerService manufacturerService, ModificationService modificationService)
        {
            _meterTypeService = meterTypeService;
            _manufacturerService = manufacturerService;
            _modificationService = modificationService;
            InitializeComponent();
            InitializeFlowMeters();
        }

        private void InitializeFlowMeters()
        {
            _flowMeters.Add(new FlowMeterSection(Flow1_CB, Flow1_GB, Flow1_Title_Label, Flow1_Type_CB, Flow1_Manufacturer_CB, Flow1_Modification_CB, Flow1_ManufactureDate_DTP, Flow1_RegistrationNumber_TB));
            _flowMeters.Add(new FlowMeterSection(Flow2_CB, Flow2_GB, Flow2_Title_Label, Flow2_Type_CB, Flow2_Manufacturer_CB, Flow2_Modification_CB, Flow2_ManufactureDate_DTP, Flow2_RegistrationNumber_TB));
            _flowMeters.Add(new FlowMeterSection(Flow3_CB, Flow3_GB, Flow3_Title_Label, Flow3_Type_CB, Flow3_Manufacturer_CB, Flow3_Modification_CB, Flow3_ManufactureDate_DTP, Flow3_RegistrationNumber_TB));
            _flowMeters.Add(new FlowMeterSection(Flow4_CB, Flow4_GB, Flow4_Title_Label, Flow4_Type_CB, Flow4_Manufacturer_CB, Flow4_Modification_CB, Flow4_ManufactureDate_DTP, Flow4_RegistrationNumber_TB));
            _flowMeters.Add(new FlowMeterSection(Flow5_CB, Flow5_GB, Flow5_Title_Label, Flow5_Type_CB, Flow5_Manufacturer_CB, Flow5_Modification_CB, Flow5_ManufactureDate_DTP, Flow5_RegistrationNumber_TB));
            _flowMeters.Add(new FlowMeterSection(Flow6_CB, Flow6_GB, Flow6_Title_Label, Flow6_Type_CB, Flow6_Manufacturer_CB, Flow6_Modification_CB, Flow6_ManufactureDate_DTP, Flow6_RegistrationNumber_TB));
        }

        private async void MetersSetupForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            foreach (var meter in _flowMeters)
            {
                FlowCB_CheckedChanged(meter.CheckBox, EventArgs.Empty);
            }

            await _meterTypeService.GetAllAsync(string.Empty, 10);
            await _manufacturerService.GetAllAsync(string.Empty, 10);
        }

        private void ResetModifications(ComboBox modificationCombo, TextBox registrationNumberTextBox)
        {
            if (_updating)
            {
                return;
            }

            modificationCombo.DataSource = null;
            modificationCombo.Items.Clear();
            modificationCombo.SelectedIndex = -1;
            _modifications.Remove(modificationCombo);
            registrationNumberTextBox.Text = string.Empty;
        }

        private void StoreAndClearCombo(ComboBox combo)
        {
            if (string.IsNullOrEmpty(combo.Text))
            {
                return;
            }

            _updating = true;
            _previousTexts[combo] = combo.Text;
            combo.Text = string.Empty;
            combo.SelectionStart = 0;
            combo.SelectionLength = 0;
            _updating = false;
        }

        private void RestoreComboText(object? sender, EventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
            {
                return;
            }

            bool noSelection = combo.SelectedIndex < 0;
            bool noText = string.IsNullOrEmpty(combo.Text);

            if (noSelection && noText && _previousTexts.TryGetValue(combo, out var text))
            {
                _updating = true;
                combo.Text = text;
                combo.SelectionStart = combo.Text.Length;
                combo.SelectionLength = 0;
                _updating = false;
            }

            _previousTexts.Remove(combo);
        }

        private void TypeCB_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                ResetModifications(meter.Modification, meter.RegistrationNumber);
            }
        }

        internal async Task PopulateMeterTypesAsync(ComboBox combo, string search, int? limit = null, bool dropDown = false)
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

        internal async Task PopulateManufacturersAsync(ComboBox combo, string search, int? limit = null, bool dropDown = false)
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

        private async Task PopulateModificationsAsync(ComboBox modificationCombo, ComboBox meterTypeCombo, ComboBox manufacturerCombo, DateTimePicker datePicker, TextBox registrationNumberTextBox)
        {
            if (meterTypeCombo.SelectedValue is not int meterTypeId)
            {
                return;
            }

            if (manufacturerCombo.SelectedValue is not int manufacturerId)
            {
                return;
            }

            var manufactureDate = DateOnly.FromDateTime(datePicker.Value);
            var items = await _modificationService.GetAllAsync(meterTypeId, manufacturerId, manufactureDate);
            _modifications[modificationCombo] = items;

            _updating = true;
            modificationCombo.BeginUpdate();
            modificationCombo.DataSource = items;
            modificationCombo.DisplayMember = nameof(ModificationDto.Name);
            modificationCombo.ValueMember = nameof(ModificationDto.Id);
            modificationCombo.SelectedIndex = -1;
            modificationCombo.EndUpdate();
            _updating = false;

            registrationNumberTextBox.Text = string.Empty;
        }

        private void UpdateRegistrationNumber(ComboBox modificationCombo, TextBox registrationNumberTextBox)
        {
            if (modificationCombo.SelectedValue is not int modificationId || !_modifications.TryGetValue(modificationCombo, out var items))
            {
                registrationNumberTextBox.Text = string.Empty;
                return;
            }

            var modification = items.FirstOrDefault(m => m.Id == modificationId);
            registrationNumberTextBox.Text = modification?.RegistrationNumber ?? string.Empty;
        }

        private void ModificationCB_TextUpdate(object? sender, EventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
            {
                return;
            }

            if (!_modifications.TryGetValue(combo, out var all))
            {
                return;
            }

            var text = combo.Text;
            var filtered = all
                .Where(m => m.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            _updating = true;
            combo.BeginUpdate();
            combo.DataSource = filtered;
            combo.DisplayMember = nameof(ModificationDto.Name);
            combo.ValueMember = nameof(ModificationDto.Id);
            combo.SelectedIndex = -1;
            combo.Text = text;
            combo.SelectionStart = text.Length;
            combo.SelectionLength = 0;
            combo.EndUpdate();
            combo.DroppedDown = true;
            Cursor.Current = Cursors.Default;
            Cursor.Show();
            _updating = false;
        }

        private void ModificationCB_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not ComboBox combo)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (combo.SelectedIndex >= 0)
                {
                    _updating = true;
                    combo.Text = combo.GetItemText(combo.SelectedItem);
                    combo.SelectionStart = combo.Text.Length;
                    combo.SelectionLength = 0;
                    _updating = false;
                }
                combo.DroppedDown = false;
            }
        }

        private void MeterTypeCB_KeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not ComboBox combo)
            {
                return;
            }

            if (_searchTokens.TryGetValue(combo, out var prev))
            {
                prev.Cancel();
            }

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
                {
                    text = combo.Text;
                }

                if (!combo.DroppedDown)
                {
                    combo.DroppedDown = true;
                    combo.SelectedIndex = -1;
                }

                int direction = e.KeyCode == Keys.Down ? 1 : -1;
                int count = combo.Items.Count;
                if (count == 0)
                {
                    return;
                }
                int newIndex = combo.SelectedIndex + direction;
                if (newIndex < 0)
                {
                    newIndex = count - 1;
                }
                if (newIndex >= count)
                {
                    newIndex = 0;
                }
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
            {
                return;
            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                return;
            }

            var keyChar = (char)e.KeyValue;
            if (!char.IsLetter(keyChar) && e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
            {
                return;
            }

            _typedTexts[combo] = combo.Text;

            if (_searchTokens.TryGetValue(combo, out var prev))
            {
                prev.Cancel();
            }

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
                StoreAndClearCombo(combo);
                await PopulateMeterTypesAsync(combo, combo.Text, combo.Text.Length > 0 ? 20 : 10, dropDown: true);
            }
        }

        private async void ManufacturerCB_KeyUp(object? sender, KeyEventArgs e)
        {
            if (_updating || sender is not ComboBox combo)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                return;
            }

            var keyChar = (char)e.KeyValue;
            if (!char.IsLetter(keyChar) && e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
            {
                return;
            }

            _typedTexts[combo] = combo.Text;

            if (_searchTokens.TryGetValue(combo, out var prev))
            {
                prev.Cancel();
            }

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
                StoreAndClearCombo(combo);
                await PopulateManufacturersAsync(combo, combo.Text, combo.Text.Length > 0 ? 20 : 10, dropDown: true);
            }
        }

        private void ManufacturerCB_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                ResetModifications(meter.Modification, meter.RegistrationNumber);
            }
        }

        private void ManufactureDateDTP_ValueChanged(object? sender, EventArgs e)
        {
            if (sender is DateTimePicker picker && picker.Tag is FlowMeterSection meter)
            {
                ResetModifications(meter.Modification, meter.RegistrationNumber);
            }
        }

        private async void ModificationCB_Click(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                StoreAndClearCombo(combo);
                await PopulateModificationsAsync(combo, meter.MeterType, meter.Manufacturer, meter.ManufactureDate, meter.RegistrationNumber);
            }
        }

        private void ModificationCB_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                UpdateRegistrationNumber(combo, meter.RegistrationNumber);
            }
        }

        private async void FlowCB_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is FlowMeterSection meter)
            {
                await meter.OnCheckedChangedAsync(this);
            }
        }
    }
}
