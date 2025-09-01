namespace PoverkaWinForms.Forms.Admin
{
    partial class CreateUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPasswordHint;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel pnlLoading;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblUserName = new Label();
            txtUserName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordHint = new Label();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblPosition = new Label();
            txtPosition = new TextBox();
            btnCreate = new Button();
            btnCancel = new Button();
            pnlLoading = new TableLayoutPanel();
            progressBar = new ProgressBar();
            pnlLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(10, 11);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(49, 15);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Логин *";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(131, 9);
            txtUserName.Margin = new Padding(3, 2, 3, 2);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(219, 23);
            txtUserName.TabIndex = 1;
            txtUserName.TextChanged += RequiredFieldsChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(10, 39);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль *";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(131, 37);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(219, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += RequiredFieldsChanged;
            // 
            // lblPasswordHint
            // 
            lblPasswordHint.AutoSize = true;
            lblPasswordHint.ForeColor = SystemColors.GrayText;
            lblPasswordHint.Location = new Point(131, 59);
            lblPasswordHint.Name = "lblPasswordHint";
            lblPasswordHint.Size = new Size(253, 45);
            lblPasswordHint.TabIndex = 4;
            lblPasswordHint.Text = "Пароль должен быть не короче 6 символов,\nсодержать цифру и спецсимвол,\nстрочную и заглавную буквы.";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(10, 128);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(42, 15);
            lblRole.TabIndex = 5;
            lblRole.Text = "Роль *";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Verifier", "Admin" });
            cmbRole.Location = new Point(131, 125);
            cmbRole.Margin = new Padding(3, 2, 3, 2);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(219, 23);
            cmbRole.TabIndex = 6;
            cmbRole.SelectedIndexChanged += RequiredFieldsChanged;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(10, 153);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(58, 15);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "Фамилия";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(131, 151);
            txtLastName.Margin = new Padding(3, 2, 3, 2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(219, 23);
            txtLastName.TabIndex = 8;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(10, 181);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(31, 15);
            lblFirstName.TabIndex = 9;
            lblFirstName.Text = "Имя";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(131, 178);
            txtFirstName.Margin = new Padding(3, 2, 3, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(219, 23);
            txtFirstName.TabIndex = 10;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Location = new Point(10, 208);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(58, 15);
            lblMiddleName.TabIndex = 11;
            lblMiddleName.Text = "Отчество";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(131, 206);
            txtMiddleName.Margin = new Padding(3, 2, 3, 2);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(219, 23);
            txtMiddleName.TabIndex = 12;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(10, 236);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(69, 15);
            lblPosition.TabIndex = 13;
            lblPosition.Text = "Должность";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(131, 234);
            txtPosition.Margin = new Padding(3, 2, 3, 2);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(219, 23);
            txtPosition.TabIndex = 14;
            // 
            // btnCreate
            // 
            btnCreate.Enabled = false;
            btnCreate.Location = new Point(131, 265);
            btnCreate.Margin = new Padding(3, 2, 3, 2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(82, 22);
            btnCreate.TabIndex = 15;
            btnCreate.Text = "Создать";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(268, 265);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlLoading
            // 
            pnlLoading.ColumnCount = 1;
            pnlLoading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlLoading.Controls.Add(progressBar, 0, 0);
            pnlLoading.Dock = DockStyle.Fill;
            pnlLoading.Location = new Point(0, 0);
            pnlLoading.Margin = new Padding(3, 2, 3, 2);
            pnlLoading.Name = "pnlLoading";
            pnlLoading.RowCount = 1;
            pnlLoading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlLoading.Size = new Size(525, 296);
            pnlLoading.TabIndex = 15;
            pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.None;
            progressBar.Location = new Point(175, 140);
            progressBar.Margin = new Padding(3, 2, 3, 2);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(175, 15);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // CreateUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 296);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(txtPosition);
            Controls.Add(lblPosition);
            Controls.Add(txtMiddleName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(lblPasswordHint);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Controls.Add(pnlLoading);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CreateUserForm";
            Text = "Создать пользователя";
            pnlLoading.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
