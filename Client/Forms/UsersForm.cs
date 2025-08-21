using System.Linq;
using System.Threading.Tasks;
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
        await LoadUsersAsync();
    }

    private async Task LoadUsersAsync()
    {
        if (_users is null) return;
        var data = await _users.GetUsersAsync();
        gridUsers.DataSource = data.ToList();
        gridUsers.ClearSelection();
        gridUsers.CurrentCell = null;
        btnEditUser.Enabled = false;
    }

    private async void btnCreateUser_Click(object? sender, EventArgs e)
    {
        if (_users is null) return;
        using var form = new CreateUserForm(_users);
        form.ShowDialog(this);
        await LoadUsersAsync();
    }

    private async void btnEditUser_Click(object? sender, EventArgs e)
    {
        if (_users is null || gridUsers.SelectedRows.Count != 1) return;
        if (gridUsers.SelectedRows[0].DataBoundItem is not UserDto user) return;
        using var form = new EditUserForm(_users, user);
        form.ShowDialog(this);
        await LoadUsersAsync();
    }
}

