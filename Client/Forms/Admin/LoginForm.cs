using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PoverkaWinForms.Services;
using PoverkaWinForms.Forms;
using PoverkaWinForms.Forms.Verifier;

namespace PoverkaWinForms.Forms.Admin;

public partial class LoginForm : Form
{
    private readonly TokenService _tokens = null!;
    private readonly IServiceProvider _provider = null!;

    public LoginForm()
    {
        InitializeComponent();
    }

    public LoginForm(TokenService tokens, IServiceProvider provider) : this()
    {
        _tokens = tokens;
        _provider = provider;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        SetLoading(true);
        try
        {
            await FormHelper.RunSafeAsync(LoginAsync);
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
            var configForm = _provider.GetRequiredService<ConfigurationForm>();
            configForm.FormClosed += ConfigForm_FormClosed;
            configForm.Show();
        }
        else
        {
            var meters = _provider.GetRequiredService<MetersSetupForm>();
            meters.FormClosed += MetersSetupForm_FormClosed;
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

    private void ConfigForm_FormClosed(object? sender, FormClosedEventArgs e) => Close();

    private void MetersSetupForm_FormClosed(object? sender, FormClosedEventArgs e) => Close();
}
