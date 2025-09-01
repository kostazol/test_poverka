namespace PoverkaWinForms.Forms.Common
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblPasswordHint;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChange;
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
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblPasswordHint = new Label();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnChange = new Button();
            btnCancel = new Button();
            pnlLoading = new TableLayoutPanel();
            progressBar = new ProgressBar();
            pnlLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(10, 11);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(100, 15);
            lblCurrentPassword.TabIndex = 0;
            lblCurrentPassword.Text = "Текущий пароль";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(158, 9);
            txtCurrentPassword.Margin = new Padding(3, 2, 3, 2);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(219, 23);
            txtCurrentPassword.TabIndex = 1;
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtCurrentPassword.TextChanged += FieldsChanged;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(10, 39);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(88, 15);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "Новый пароль";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(158, 37);
            txtNewPassword.Margin = new Padding(3, 2, 3, 2);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(219, 23);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.TextChanged += FieldsChanged;
            // 
            // lblPasswordHint
            // 
            lblPasswordHint.AutoSize = true;
            lblPasswordHint.ForeColor = SystemColors.GrayText;
            lblPasswordHint.Location = new Point(158, 59);
            lblPasswordHint.Name = "lblPasswordHint";
            lblPasswordHint.Size = new Size(253, 45);
            lblPasswordHint.TabIndex = 4;
            lblPasswordHint.Text = "Пароль должен быть не короче 6 символов,\nсодержать цифру и спецсимвол,\nстрочную и заглавную буквы.";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(10, 129);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(109, 15);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Повторите пароль";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(158, 127);
            txtConfirmPassword.Margin = new Padding(3, 2, 3, 2);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(219, 23);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += FieldsChanged;
            // 
            // btnChange
            // 
            btnChange.Enabled = false;
            btnChange.Location = new Point(158, 159);
            btnChange.Margin = new Padding(3, 2, 3, 2);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(82, 22);
            btnChange.TabIndex = 7;
            btnChange.Text = "Изменить";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(329, 159);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 8;
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
            pnlLoading.Size = new Size(560, 190);
            pnlLoading.TabIndex = 9;
            pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.None;
            progressBar.Location = new Point(192, 87);
            progressBar.Margin = new Padding(3, 2, 3, 2);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(175, 15);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 190);
            Controls.Add(btnCancel);
            Controls.Add(btnChange);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblPasswordHint);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrentPassword);
            Controls.Add(pnlLoading);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChangePasswordForm";
            Text = "Изменить пароль";
            pnlLoading.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
