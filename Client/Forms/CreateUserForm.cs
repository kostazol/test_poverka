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
            cmbRole.SelectedItem is not null &&
            IsPasswordValid(txtPassword.Text);
    }

    private static bool IsPasswordValid(string password) =>
        !string.IsNullOrWhiteSpace(password) && password.Length <= 16;

    private async void btnCreate_Click(object? sender, EventArgs e)
    {
        if (_users is null) return;

        SetLoading(true);
        try
        {
            var dto = new UserCreateDto(
                txtUserName.Text,
                txtPassword.Text,
                (string)cmbRole.SelectedItem!,
                string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text,
                string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text,
                string.IsNullOrWhiteSpace(txtMiddleName.Text) ? null : txtMiddleName.Text);
            await _users.CreateUserAsync(dto);
            DialogResult = DialogResult.OK;
            Close();
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void SetLoading(bool loading)
    {
        pnlLoading.Visible = loading;
        foreach (Control control in Controls)
        {
            if (control != pnlLoading)
                control.Enabled = !loading;
        }
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

