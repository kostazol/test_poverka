namespace PoverkaWinForms.Forms.Admin
{
    partial class SetPasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPasswordHint;
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
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordHint = new Label();
            btnChange = new Button();
            btnCancel = new Button();
            pnlLoading = new TableLayoutPanel();
            progressBar = new ProgressBar();
            pnlLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(10, 11);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(49, 15);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Пароль";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(131, 9);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(219, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblPasswordHint
            // 
            lblPasswordHint.AutoSize = true;
            lblPasswordHint.ForeColor = SystemColors.GrayText;
            lblPasswordHint.Location = new Point(131, 32);
            lblPasswordHint.Name = "lblPasswordHint";
            lblPasswordHint.Size = new Size(253, 45);
            lblPasswordHint.TabIndex = 2;
            lblPasswordHint.Text = "Пароль должен быть не короче 6 символов,\nсодержать цифру и спецсимвол,\nстрочную и заглавную буквы.";
            // 
            // btnChange
            // 
            btnChange.Enabled = false;
            btnChange.Location = new Point(131, 99);
            btnChange.Margin = new Padding(3, 2, 3, 2);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(82, 22);
            btnChange.TabIndex = 3;
            btnChange.Text = "Изменить";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(268, 99);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 4;
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
            pnlLoading.Size = new Size(525, 142);
            pnlLoading.TabIndex = 5;
            pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.None;
            progressBar.Location = new Point(175, 63);
            progressBar.Margin = new Padding(3, 2, 3, 2);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(175, 15);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // SetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 142);
            Controls.Add(btnCancel);
            Controls.Add(btnChange);
            Controls.Add(lblPasswordHint);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(pnlLoading);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SetPasswordForm";
            Text = "Установить пароль";
            pnlLoading.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
