using System;
using System.Windows.Forms;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms;

public partial class CreateUserForm : Form
{
    private readonly UserService? _users;

    public CreateUserForm()
    {
        InitializeComponent();
    }

    public CreateUserForm(UserService users) : this()
    {
        _users = users;
    }

    private void RequiredFieldsChanged(object? sender, EventArgs e)
    {
        btnCreate.Enabled =
            !string.IsNullOrWhiteSpace(txtUserName.Text) &&
            !string.IsNullOrWhiteSpace(txtPassword.Text) &&
            cmbRole.SelectedItem is not null;
    }

    private async void btnCreate_Click(object? sender, EventArgs e)
    {
        if (_users is null) return;

        var dto = new UserCreateDto(txtUserName.Text, txtPassword.Text, (string)cmbRole.SelectedItem!);
        await _users.CreateUserAsync(dto);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

