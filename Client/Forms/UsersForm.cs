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
        gridUsers.SelectionChanged += (s, e) =>
            btnEditUser.Enabled = gridUsers.SelectedRows.Count == 1;
    }

    public UsersForm(UserService users) : this()
    {
        _users = users;
        Load += async (s, e) =>
        {
            var data = await _users!.GetUsersAsync();
            gridUsers.DataSource = data.ToList();
        };
    }
}

