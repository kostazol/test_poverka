namespace PoverkaWinForms.Forms.Admin
{
    partial class EditUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Button btnSave;
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
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblPosition = new Label();
            txtPosition = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            pnlLoading = new TableLayoutPanel();
            progressBar = new ProgressBar();
            pnlLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(10, 11);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(58, 15);
            lblLastName.TabIndex = 0;
            lblLastName.Text = "Фамилия";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(131, 9);
            txtLastName.Margin = new Padding(3, 2, 3, 2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(219, 23);
            txtLastName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(10, 39);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(31, 15);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "Имя";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(131, 37);
            txtFirstName.Margin = new Padding(3, 2, 3, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(219, 23);
            txtFirstName.TabIndex = 3;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Location = new Point(10, 67);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(58, 15);
            lblMiddleName.TabIndex = 4;
            lblMiddleName.Text = "Отчество";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(131, 64);
            txtMiddleName.Margin = new Padding(3, 2, 3, 2);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(219, 23);
            txtMiddleName.TabIndex = 5;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(10, 94);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(69, 15);
            lblPosition.TabIndex = 6;
            lblPosition.Text = "Должность";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(131, 92);
            txtPosition.Margin = new Padding(3, 2, 3, 2);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(219, 23);
            txtPosition.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(131, 125);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(268, 125);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 9;
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
            pnlLoading.Size = new Size(362, 156);
            pnlLoading.TabIndex = 10;
            pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.None;
            progressBar.Location = new Point(93, 70);
            progressBar.Margin = new Padding(3, 2, 3, 2);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(175, 15);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 156);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPosition);
            Controls.Add(lblPosition);
            Controls.Add(txtMiddleName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(pnlLoading);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EditUserForm";
            Text = "Изменение пользователя";
            Load += EditUserForm_Load;
            pnlLoading.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

