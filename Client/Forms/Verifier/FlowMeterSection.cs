using System.Threading.Tasks;
using System.Windows.Forms;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms.Verifier;

internal sealed class FlowMeterSection
{
    public FlowMeterSection(CheckBox checkBox, GroupBox groupBox, Label caption, ComboBox meterType, ComboBox manufacturer, ComboBox modification, DateTimePicker manufactureDate, TextBox registrationNumber)
    {
        CheckBox = checkBox;
        GroupBox = groupBox;
        Caption = caption;
        MeterType = meterType;
        Manufacturer = manufacturer;
        Modification = modification;
        ManufactureDate = manufactureDate;
        RegistrationNumber = registrationNumber;

        checkBox.Tag = this;
        meterType.Tag = this;
        manufacturer.Tag = this;
        modification.Tag = this;
        manufactureDate.Tag = this;
        registrationNumber.Tag = this;
    }

    public CheckBox CheckBox { get; }
    public GroupBox GroupBox { get; }
    public Label Caption { get; }
    public ComboBox MeterType { get; }
    public ComboBox Manufacturer { get; }
    public ComboBox Modification { get; }
    public DateTimePicker ManufactureDate { get; }
    public TextBox RegistrationNumber { get; }

    public bool IsComplete()
    {
        return MeterType.SelectedItem != null
            && !string.IsNullOrWhiteSpace(Manufacturer.Text)
            && Modification.SelectedItem != null
            && !string.IsNullOrWhiteSpace(RegistrationNumber.Text);
    }

    public void ToggleControls()
    {
        bool visible = CheckBox.Checked;
        foreach (Control control in GroupBox.Controls)
        {
            if (control != Caption && control != CheckBox)
                control.Visible = visible;
        }
    }

    public async Task OnCheckedChangedAsync(MetersSetupForm form)
    {
        ToggleControls();

        if (!CheckBox.Checked)
            return;

        await form.PopulateMeterTypesAsync(MeterType, string.Empty, 10);
        await form.PopulateManufacturersAsync(Manufacturer, string.Empty, 10);
    }

    public async Task<FlowMeterInfo> ToInfoAsync(RegistrationService registrations)
    {
        if (!CheckBox.Checked)
        {
            return new FlowMeterInfo(null, null, null, null);
        }

        var selectedType = MeterType.SelectedItem as MeterTypeDto;
        var manufacturerName = string.IsNullOrWhiteSpace(Manufacturer.Text) ? null : Manufacturer.Text;
        var selectedModification = Modification.SelectedItem as ModificationDto;

        var selectedRegistration = selectedModification is null
            ? null
            : await registrations.GetAsync(selectedModification.RegistrationId);

        return new FlowMeterInfo(selectedType, manufacturerName, selectedModification, selectedRegistration);
    }
}
