using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoverkaWinForms.Services;
using PoverkaWinForms.UI;

namespace PoverkaWinForms.Forms;

public partial class ConfigurationForm : Form
{
    private readonly UserService? _users;

    public ConfigurationForm()
    {
        InitializeComponent();
    }

    public ConfigurationForm(UserService users) : this()
    {
        _users = users;
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
        if (_users is null) return;

        await UiHelper.RunSafeAsync(async () =>
        {
            SetLoading(true);
            try
            {
                var data = await _users.GetUsersAsync();
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
        if (_users is null) return;
        using var form = new CreateUserForm(_users);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
            MessageBox.Show("Пользователь создан");
        await LoadUsersAsync();
    }

    private async void btnEditUser_Click(object? sender, EventArgs e)
    {
        if (_users is null || gridUsers.SelectedRows.Count != 1) return;
        if (gridUsers.SelectedRows[0].DataBoundItem is not UserDto user) return;
        using var form = new EditUserForm(_users, user);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
            MessageBox.Show("Пользователь успешно изменен");
        await LoadUsersAsync();
    }

    private void btnChangePassword_Click(object? sender, EventArgs e)
    {
        if (_users is null || gridUsers.SelectedRows.Count != 1) return;
        if (gridUsers.SelectedRows[0].DataBoundItem is not UserDto user) return;
        using var form = new SetPasswordForm(_users, user.Id);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
            MessageBox.Show("Пароль успешно изменен");
    }

    private void btnChangeMyPassword_Click(object? sender, EventArgs e)
    {
        if (_users is null) return;
        using var form = new ChangePasswordForm(_users);
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
}

