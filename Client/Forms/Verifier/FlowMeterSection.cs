using System.Threading.Tasks;
using System.Windows.Forms;

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

    public string? SelectedType { get; private set; }
    public string? SelectedManufacturer { get; private set; }
    public string? SelectedModification { get; private set; }
    public string? SelectedRegistration { get; private set; }

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

    public void SaveSelections()
    {
        if (!CheckBox.Checked)
        {
            SelectedType = null;
            SelectedManufacturer = null;
            SelectedModification = null;
            SelectedRegistration = null;
            return;
        }

        SelectedType = MeterType.SelectedIndex >= 0
            ? MeterType.GetItemText(MeterType.SelectedItem)
            : MeterType.Text;
        SelectedManufacturer = Manufacturer.SelectedIndex >= 0
            ? Manufacturer.GetItemText(Manufacturer.SelectedItem)
            : Manufacturer.Text;
        SelectedModification = Modification.SelectedIndex >= 0
            ? Modification.GetItemText(Modification.SelectedItem)
            : Modification.Text;
        SelectedRegistration = RegistrationNumber.Text;
    }

    public FlowMeterInfo ToInfo() => new(SelectedType, SelectedManufacturer, SelectedModification, SelectedRegistration);
}
