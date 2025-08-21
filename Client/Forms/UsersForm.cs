using System.Linq;
using System.Windows.Forms;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms;

public partial class UsersForm : Form
{
    private readonly UserService? _users;

    public UsersForm()
    {
        InitializeComponent();
    }

    public UsersForm(UserService users) : this()
    {
        _users = users;
    }

    private void gridUsers_SelectionChanged(object? sender, EventArgs e)
    {
        btnEditUser.Enabled = gridUsers.SelectedRows.Count == 1;
    }

    private async void UsersForm_Load(object? sender, EventArgs e)
    {
        if (_users is null) return;
        var data = await _users.GetUsersAsync();
        gridUsers.DataSource = data.ToList();
    }
}

