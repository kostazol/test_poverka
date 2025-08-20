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
        btnLogin.Click += async (s, e) => await UiHelper.RunSafeAsync(LoginAsync);
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
        var meters = _provider.GetRequiredService<MetersSetupForm>();
        meters.FormClosed += (_, _) => Close();
        meters.Show();
    }
}
