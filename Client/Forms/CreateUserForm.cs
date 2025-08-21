using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using PoverkaWinForms.Services;
using PoverkaWinForms.UI;

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
        var passwordValid = IsPasswordValid(txtPassword.Text);
        txtPassword.BackColor = txtPassword.TextLength == 0 || passwordValid
            ? SystemColors.Window
            : Color.MistyRose;
        btnCreate.Enabled =
            !string.IsNullOrWhiteSpace(txtUserName.Text) &&
            cmbRole.SelectedItem is not null &&
            passwordValid;
    }

    private static bool IsPasswordValid(string password) =>
        !string.IsNullOrWhiteSpace(password) &&
        password.Length >= 6 &&
        password.Any(char.IsLower) &&
        password.Any(char.IsUpper) &&
        password.Any(char.IsDigit) &&
        password.Any(ch => !char.IsLetterOrDigit(ch));

    private async void btnCreate_Click(object? sender, EventArgs e)
    {
        if (_users is null) return;

        await UiHelper.RunSafeAsync(async () =>
        {
            SetLoading(true);
            try
            {
                var dto = new UserCreateDto(
                    txtUserName.Text,
                    txtPassword.Text,
                    (string)cmbRole.SelectedItem!,
                    string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text,
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text,
                    string.IsNullOrWhiteSpace(txtMiddleName.Text) ? null : txtMiddleName.Text,
                    string.IsNullOrWhiteSpace(txtPosition.Text) ? null : txtPosition.Text);
                await _users.CreateUserAsync(dto);
                DialogResult = DialogResult.OK;
                Close();
            }
            finally
            {
                SetLoading(false);
            }
        });
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

