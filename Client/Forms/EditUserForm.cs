using System;
using System.Windows.Forms;
using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms;

public partial class EditUserForm : Form
{
    private readonly UserService? _users;
    private readonly UserDto? _user;

    public EditUserForm()
    {
        InitializeComponent();
    }

    public EditUserForm(UserService users, UserDto user) : this()
    {
        _users = users;
        _user = user;
    }

    private void EditUserForm_Load(object? sender, EventArgs e)
    {
        if (_user is null) return;
        txtLastName.Text = _user.LastName;
        txtFirstName.Text = _user.FirstName;
        txtMiddleName.Text = _user.MiddleName;
    }

    private async void btnSave_Click(object? sender, EventArgs e)
    {
        if (_users is null || _user is null) return;
        var dto = new UserUpdateDto(txtLastName.Text, txtFirstName.Text, txtMiddleName.Text);
        await _users.UpdateUserAsync(_user.Id, dto);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

