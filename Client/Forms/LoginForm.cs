using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PoverkaWinForms.Services;
using PoverkaWinForms.UI;

namespace PoverkaWinForms.Forms;

public partial class LoginForm : Form
{
    private readonly TokenService _tokens;
    private readonly IServiceProvider _provider;

    public LoginForm(TokenService tokens, IServiceProvider provider)
    {
        InitializeComponent();
        _tokens = tokens;
        _provider = provider;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        SetLoading(true);
        try
        {
            await UiHelper.RunSafeAsync(LoginAsync);
        }
        finally
        {
            SetLoading(false);
        }
    }

    private async Task LoginAsync()
    {
        var success = await _tokens.LoginAsync(txtUser.Text, txtPass.Text);
        if (!success)
        {
            MessageBox.Show("Логин или пароль не верные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Hide();
        if (_tokens.Role == "Admin")
        {
            var usersForm = _provider.GetRequiredService<UsersForm>();
            usersForm.FormClosed += (_, _) => Close();
            usersForm.Show();
        }
        else
        {
            var meters = _provider.GetRequiredService<MetersSetupForm>();
            meters.FormClosed += (_, _) => Close();
            meters.Show();
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
}
