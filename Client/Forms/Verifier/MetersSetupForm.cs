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
            _flowMeters.Add(new FlowMeterSection(Flow1CheckBox, Flow1GroupBox, Flow1TitleLabel, Flow1TypeComboBox, Flow1ManufacturerComboBox, Flow1ModificationComboBox, Flow1ManufactureDateDateTimePicker, Flow1RegistrationNumberTextBox));
            _flowMeters.Add(new FlowMeterSection(Flow2CheckBox, Flow2GroupBox, Flow2TitleLabel, Flow2TypeComboBox, Flow2ManufacturerComboBox, Flow2ModificationComboBox, Flow2ManufactureDateDateTimePicker, Flow2RegistrationNumberTextBox));
            _flowMeters.Add(new FlowMeterSection(Flow3CheckBox, Flow3GroupBox, Flow3TitleLabel, Flow3TypeComboBox, Flow3ManufacturerComboBox, Flow3ModificationComboBox, Flow3ManufactureDateDateTimePicker, Flow3RegistrationNumberTextBox));
            _flowMeters.Add(new FlowMeterSection(Flow4CheckBox, Flow4GroupBox, Flow4TitleLabel, Flow4TypeComboBox, Flow4ManufacturerComboBox, Flow4ModificationComboBox, Flow4ManufactureDateDateTimePicker, Flow4RegistrationNumberTextBox));
            _flowMeters.Add(new FlowMeterSection(Flow5CheckBox, Flow5GroupBox, Flow5TitleLabel, Flow5TypeComboBox, Flow5ManufacturerComboBox, Flow5ModificationComboBox, Flow5ManufactureDateDateTimePicker, Flow5RegistrationNumberTextBox));
            _flowMeters.Add(new FlowMeterSection(Flow6CheckBox, Flow6GroupBox, Flow6TitleLabel, Flow6TypeComboBox, Flow6ManufacturerComboBox, Flow6ModificationComboBox, Flow6ManufactureDateDateTimePicker, Flow6RegistrationNumberTextBox));
        }

        private async void MetersSetupFormLoad(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            foreach (var meter in _flowMeters)
            {
                FlowCheckBoxCheckedChanged(meter.CheckBox, EventArgs.Empty);
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

        private void TypeComboBoxSelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                ResetModifications(meter.Modification, meter.RegistrationNumber);
            }
        }

        private async Task PopulateComboAsync<T>(ComboBox combo, string search, int? limit, bool dropDown, Func<string, int?, Task<List<T>>> fetch, string displayMember, string valueMember)
        {
            var items = await fetch(search, limit);

            var selStart = combo.SelectionStart;
            _updating = true;
            combo.BeginUpdate();
            combo.DataSource = items;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
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

        internal Task PopulateMeterTypesAsync(ComboBox combo, string search, int? limit = null, bool dropDown = false) => PopulateComboAsync(combo, search, limit, dropDown, _meterTypeService.GetAllAsync, nameof(MeterTypeDto.Type), nameof(MeterTypeDto.Id));

        internal Task PopulateManufacturersAsync(ComboBox combo, string search, int? limit = null, bool dropDown = false) => PopulateComboAsync(combo, search, limit, dropDown, _manufacturerService.GetAllAsync, nameof(ManufacturerDto.Name), nameof(ManufacturerDto.Id));

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

        private void ModificationComboBoxTextUpdate(object? sender, EventArgs e)
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

        private void ModificationComboBoxKeyDown(object? sender, KeyEventArgs e)
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

        private void MeterTypeComboBoxKeyDown(object? sender, KeyEventArgs e)
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

        private async void MeterTypeComboBoxKeyUp(object? sender, KeyEventArgs e)
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

        private async void MeterTypeComboBoxClick(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo)
            {
                StoreAndClearCombo(combo);
                await PopulateMeterTypesAsync(combo, combo.Text, combo.Text.Length > 0 ? 20 : 10, dropDown: true);
            }
        }

        private async void ManufacturerComboBoxKeyUp(object? sender, KeyEventArgs e)
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

        private async void ManufacturerComboBoxClick(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo)
            {
                StoreAndClearCombo(combo);
                await PopulateManufacturersAsync(combo, combo.Text, combo.Text.Length > 0 ? 20 : 10, dropDown: true);
            }
        }

        private void ManufacturerComboBoxSelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                ResetModifications(meter.Modification, meter.RegistrationNumber);
            }
        }

        private void ManufactureDateDateTimePickerValueChanged(object? sender, EventArgs e)
        {
            if (sender is DateTimePicker picker && picker.Tag is FlowMeterSection meter)
            {
                ResetModifications(meter.Modification, meter.RegistrationNumber);
            }
        }

        private async void ModificationComboBoxClick(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                StoreAndClearCombo(combo);
                await PopulateModificationsAsync(combo, meter.MeterType, meter.Manufacturer, meter.ManufactureDate, meter.RegistrationNumber);
            }
        }

        private void ModificationComboBoxSelectedIndexChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.Tag is FlowMeterSection meter)
            {
                UpdateRegistrationNumber(combo, meter.RegistrationNumber);
            }
        }

        private async void FlowCheckBoxCheckedChanged(object? sender, EventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is FlowMeterSection meter)
            {
                await meter.OnCheckedChangedAsync(this);
            }
        }
    }
}
