using System.Windows.Forms;

namespace PoverkaWinForms.Forms;

partial class LoginForm
{
    private TextBox txtUser;
    private TextBox txtPass;
    private Button btnLogin;

    private void InitializeComponent()
    {
        txtUser = new TextBox();
        txtPass = new TextBox();
        btnLogin = new Button();
        SuspendLayout();
        // 
        // txtUser
        // 
        txtUser.Location = new Point(10, 10);
        txtUser.Name = "txtUser";
        txtUser.PlaceholderText = "Login";
        txtUser.Size = new Size(200, 23);
        txtUser.TabIndex = 0;
        // 
        // txtPass
        // 
        txtPass.Location = new Point(10, 40);
        txtPass.Name = "txtPass";
        txtPass.PlaceholderText = "Password";
        txtPass.Size = new Size(200, 23);
        txtPass.TabIndex = 1;
        txtPass.UseSystemPasswordChar = true;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(10, 70);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(200, 23);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(224, 111);
        Controls.Add(btnLogin);
        Controls.Add(txtPass);
        Controls.Add(txtUser);
        Name = "LoginForm";
        Text = "Login";
        ResumeLayout(false);
        PerformLayout();
    }
}

