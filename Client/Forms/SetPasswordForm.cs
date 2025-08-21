using System;
using System.Linq;
using System.Windows.Forms;
using PoverkaWinForms.Services;
using PoverkaWinForms.UI;

namespace PoverkaWinForms.Forms;

public partial class SetPasswordForm : Form
{
    private readonly UserService? _users;
    private readonly string? _userId;

    public SetPasswordForm()
    {
        InitializeComponent();
    }

    public SetPasswordForm(UserService users, string userId) : this()
    {
        _users = users;
        _userId = userId;
    }

    private void txtPassword_TextChanged(object? sender, EventArgs e)
    {
        btnChange.Enabled = IsPasswordValid(txtPassword.Text);
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
        if (_users is null || _userId is null) return;

        await UiHelper.RunSafeAsync(async () =>
        {
            SetLoading(true);
            try
            {
                var dto = new SetPasswordDto(txtPassword.Text);
                await _users.SetPasswordAsync(_userId, dto);
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
