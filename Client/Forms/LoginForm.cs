using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms;

public class LoginForm : Form
{
    private readonly TextBox _user = new() { PlaceholderText = "Login" };
    private readonly TextBox _pass = new() { PlaceholderText = "Password", UseSystemPasswordChar = true };
    private readonly Button _loginButton = new() { Text = "Login" };
    private readonly TokenService _tokens;
    private readonly IServiceProvider _provider;

    public LoginForm(TokenService tokens, IServiceProvider provider)
    {
        _tokens = tokens;
        _provider = provider;
        Text = "Login";
        Controls.AddRange(new Control[] { _user, _pass, _loginButton });
        _user.Top = 10; _user.Left = 10; _user.Width = 200;
        _pass.Top = 40; _pass.Left = 10; _pass.Width = 200;
        _loginButton.Top = 70; _loginButton.Left = 10;
        _loginButton.Click += async (s, e) => await LoginAsync();
    }

    private async Task LoginAsync()
    {
        var success = await _tokens.LoginAsync(_user.Text, _pass.Text);
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
