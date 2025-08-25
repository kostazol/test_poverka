namespace PoverkaWinForms.Forms.Admin
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
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordHint = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlLoading = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pnlLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Location = new System.Drawing.Point(12, 15);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(119, 20);
            this.lblCurrentPassword.TabIndex = 0;
            this.lblCurrentPassword.Text = "Текущий пароль";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(180, 12);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(250, 27);
            this.txtCurrentPassword.TabIndex = 1;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            this.txtCurrentPassword.TextChanged += new System.EventHandler(this.FieldsChanged);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(12, 52);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(106, 20);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "Новый пароль";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(180, 49);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(250, 27);
            this.txtNewPassword.TabIndex = 3;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.FieldsChanged);
            // 
            // lblPasswordHint
            // 
            this.lblPasswordHint.AutoSize = true;
            this.lblPasswordHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPasswordHint.Location = new System.Drawing.Point(180, 79);
            this.lblPasswordHint.Name = "lblPasswordHint";
            this.lblPasswordHint.Size = new System.Drawing.Size(413, 60);
            this.lblPasswordHint.TabIndex = 4;
            this.lblPasswordHint.Text = "Пароль должен быть не короче 6 символов,\nсодержать цифру и спецсимвол,\nстрочную и заглавную буквы.";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(12, 172);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(142, 20);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Повторите пароль";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(180, 169);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(250, 27);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.FieldsChanged);
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(180, 212);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(94, 29);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(376, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlLoading
            // 
            this.pnlLoading.ColumnCount = 1;
            this.pnlLoading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLoading.Controls.Add(this.progressBar, 0, 0);
            this.pnlLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoading.Location = new System.Drawing.Point(0, 0);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.RowCount = 1;
            this.pnlLoading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLoading.Size = new System.Drawing.Size(640, 253);
            this.pnlLoading.TabIndex = 9;
            this.pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(220, 116);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 253);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblPasswordHint);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.Name = "ChangePasswordForm";
            this.Text = "Изменить пароль";
            this.pnlLoading.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
