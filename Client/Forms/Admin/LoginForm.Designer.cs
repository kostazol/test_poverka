using System.Windows.Forms;

namespace PoverkaWinForms.Forms.Admin;

partial class LoginForm
{
    private TextBox txtUser;
    private TextBox txtPass;
    private Button btnLogin;
    private TableLayoutPanel pnlLoading;
    private ProgressBar progressBar;

    private void InitializeComponent()
    {
        txtUser = new TextBox();
        txtPass = new TextBox();
        btnLogin = new Button();
        pnlLoading = new TableLayoutPanel();
        progressBar = new ProgressBar();
        pnlLoading.SuspendLayout();
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
        // pnlLoading
        //
        pnlLoading.ColumnCount = 1;
        pnlLoading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        pnlLoading.Controls.Add(progressBar, 0, 0);
        pnlLoading.Location = new Point(10, 100);
        pnlLoading.Name = "pnlLoading";
        pnlLoading.RowCount = 1;
        pnlLoading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        pnlLoading.Size = new Size(200, 23);
        pnlLoading.TabIndex = 3;
        pnlLoading.Visible = false;
        //
        // progressBar
        //
        progressBar.Dock = DockStyle.Fill;
        progressBar.MarqueeAnimationSpeed = 30;
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(200, 20);
        progressBar.Style = ProgressBarStyle.Marquee;
        progressBar.TabIndex = 0;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(224, 151);
        Controls.Add(pnlLoading);
        Controls.Add(btnLogin);
        Controls.Add(txtPass);
        Controls.Add(txtUser);
        AcceptButton = btnLogin;
        Name = "LoginForm";
        Text = "Login";
        pnlLoading.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}

