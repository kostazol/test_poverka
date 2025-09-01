using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoverkaWinForms.Services;
using PoverkaWinForms.Forms;
using PoverkaWinForms.Forms.Common;

namespace PoverkaWinForms.Forms.Admin;

public partial class ConfigurationForm : Form
{
    private readonly UserService? _userService;
    private readonly MeterImportService? _meterImportService;

    public ConfigurationForm()
    {
        InitializeComponent();
    }

    public ConfigurationForm(UserService userService, MeterImportService meterImportService) : this()
    {
        _userService = userService;
        _meterImportService = meterImportService;
    }

    private void gridUsers_SelectionChanged(object? sender, EventArgs e)
    {
        var selected = gridUsers.SelectedRows.Count == 1;
        btnEditUser.Enabled = selected;
        btnChangePassword.Enabled = selected;
    }

    private async void ConfigurationForm_Load(object? sender, EventArgs e)
    {
        tabControl.SelectedTab = tabUsers;
        await LoadUsersAsync();
    }

    private async Task LoadUsersAsync()
    {
        if (_userService is null) return;

        await FormHelper.RunSafeAsync(async () =>
        {
            SetLoading(true);
            try
            {
                var data = await _userService.GetUsersAsync();
                gridUsers.DataSource = data.ToList();
                if (gridUsers.Columns[nameof(UserDto.Position)] is DataGridViewColumn positionColumn)
                    positionColumn.HeaderText = "Должность";
                gridUsers.ClearSelection();
                gridUsers.CurrentCell = null;
                btnEditUser.Enabled = false;
                btnChangePassword.Enabled = false;
            }
            finally
            {
                SetLoading(false);
            }
        });
    }

    private async void btnCreateUser_Click(object? sender, EventArgs e)
    {
        if (_userService is null) return;
        using var form = new CreateUserForm(_userService);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
            MessageBox.Show("Пользователь создан");
        await LoadUsersAsync();
    }

    private async void btnEditUser_Click(object? sender, EventArgs e)
    {
        if (_userService is null || gridUsers.SelectedRows.Count != 1) return;
        if (gridUsers.SelectedRows[0].DataBoundItem is not UserDto user) return;
        using var form = new EditUserForm(_userService, user);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
            MessageBox.Show("Пользователь успешно изменен");
        await LoadUsersAsync();
    }

    private void btnChangePassword_Click(object? sender, EventArgs e)
    {
        if (_userService is null || gridUsers.SelectedRows.Count != 1) return;
        if (gridUsers.SelectedRows[0].DataBoundItem is not UserDto user) return;
        using var form = new SetPasswordForm(_userService, user.Id);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
            MessageBox.Show("Пароль успешно изменен");
    }

    private void btnChangeMyPassword_Click(object? sender, EventArgs e)
    {
        if (_userService is null) return;
        using var form = new ChangePasswordForm(_userService);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
            MessageBox.Show("Пароль изменен, при следующем входе используйте новый пароль");
    }

    private void SetLoading(bool loading)
    {
        pnlLoading.Visible = loading;
        panelTop.Enabled = !loading;
        gridUsers.Enabled = !loading;
    }

    private void btnAddFromFile_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            txtCsvPath.Text = dialog.FileName;
        }
    }

    private async void btnProcessFile_Click(object? sender, EventArgs e)
    {
        if (_meterImportService is null || string.IsNullOrWhiteSpace(txtCsvPath.Text))
        {
            return;
        }

        await FormHelper.RunSafeAsync(async () =>
        {
            await _meterImportService.ImportAsync(txtCsvPath.Text);
            MessageBox.Show("Файл обработан");
        });
    }
}

