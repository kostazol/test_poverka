namespace PoverkaWinForms.Forms
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
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordHint = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlLoading = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pnlLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 15);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 20);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Пароль";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(250, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblPasswordHint
            // 
            this.lblPasswordHint.AutoSize = true;
            this.lblPasswordHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPasswordHint.Location = new System.Drawing.Point(150, 42);
            this.lblPasswordHint.Name = "lblPasswordHint";
            this.lblPasswordHint.Size = new System.Drawing.Size(413, 40);
            this.lblPasswordHint.TabIndex = 2;
            this.lblPasswordHint.Text = "Пароль должен быть не короче 6 символов и содержать цифру,\nспецсимвол, строчную и заглавную буквы.";
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(150, 100);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(94, 29);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "Изменить";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(306, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 4;
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
            this.pnlLoading.Size = new System.Drawing.Size(442, 143);
            this.pnlLoading.TabIndex = 5;
            this.pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(121, 61);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            // 
            // SetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 143);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblPasswordHint);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Name = "SetPasswordForm";
            this.Text = "Установить пароль";
            this.pnlLoading.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
