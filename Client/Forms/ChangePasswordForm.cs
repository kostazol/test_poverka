using System;
using System.Linq;
using System.Windows.Forms;
using PoverkaWinForms.Services;
using PoverkaWinForms.UI;

namespace PoverkaWinForms.Forms;

public partial class ChangePasswordForm : Form
{
    private readonly UserService? _users;

    public ChangePasswordForm()
    {
        InitializeComponent();
    }

    public ChangePasswordForm(UserService users) : this()
    {
        _users = users;
    }

    private void FieldsChanged(object? sender, EventArgs e)
    {
        btnChange.Enabled =
            !string.IsNullOrWhiteSpace(txtCurrentPassword.Text) &&
            !string.IsNullOrWhiteSpace(txtNewPassword.Text) &&
            !string.IsNullOrWhiteSpace(txtConfirmPassword.Text) &&
            txtNewPassword.Text == txtConfirmPassword.Text &&
            IsPasswordValid(txtNewPassword.Text);
    }

    private static bool IsPasswordValid(string password) =>
        !string.IsNullOrWhiteSpace(password) &&
        password.Length >= 6 &&
        password.Any(char.IsLower) &&
        password.Any(char.IsUpper) &&
        password.Any(char.IsDigit) &&
        password.Any(ch => !char.IsLetterOrDigit(ch));

    private async void btnChange_Click(object? sender, EventArgs e)
    {
        if (_users is null) return;

        await UiHelper.RunSafeAsync(async () =>
        {
            SetLoading(true);
            try
            {
                var dto = new ChangePasswordDto(txtCurrentPassword.Text, txtNewPassword.Text);
                await _users.ChangePasswordAsync(dto);
                DialogResult = DialogResult.OK;
                Close();
            }
            finally
            {
                SetLoading(false);
            }
        });
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
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
}
