namespace PoverkaWinForms.Forms
{
    partial class UsersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnChangeMyPassword;
        private System.Windows.Forms.TableLayoutPanel pnlLoading;
        private System.Windows.Forms.ProgressBar progressBar;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            gridUsers = new DataGridView();
            panelTop = new Panel();
            btnChangeMyPassword = new Button();
            btnChangePassword = new Button();
            btnEditUser = new Button();
            btnCreateUser = new Button();
            pnlLoading = new TableLayoutPanel();
            progressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            panelTop.SuspendLayout();
            pnlLoading.SuspendLayout();
            SuspendLayout();
            // 
            // gridUsers
            // 
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Dock = DockStyle.Fill;
            gridUsers.Location = new Point(0, 40);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 51;
            gridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new Size(969, 410);
            gridUsers.TabIndex = 1;
            gridUsers.SelectionChanged += gridUsers_SelectionChanged;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnChangeMyPassword);
            panelTop.Controls.Add(btnChangePassword);
            panelTop.Controls.Add(btnEditUser);
            panelTop.Controls.Add(btnCreateUser);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(969, 40);
            panelTop.TabIndex = 0;
            // 
            // btnChangeMyPassword
            // 
            btnChangeMyPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeMyPassword.Location = new Point(755, 7);
            btnChangeMyPassword.Name = "btnChangeMyPassword";
            btnChangeMyPassword.Size = new Size(202, 29);
            btnChangeMyPassword.TabIndex = 3;
            btnChangeMyPassword.Text = "Изменить свой пароль";
            btnChangeMyPassword.UseVisualStyleBackColor = true;
            btnChangeMyPassword.Click += btnChangeMyPassword_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Enabled = false;
            btnChangePassword.Location = new Point(324, 7);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(150, 29);
            btnChangePassword.TabIndex = 2;
            btnChangePassword.Text = "Изменить пароль";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Enabled = false;
            btnEditUser.Location = new Point(168, 7);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(150, 29);
            btnEditUser.TabIndex = 1;
            btnEditUser.Text = "Изменить пользователя";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(12, 7);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(150, 29);
            btnCreateUser.TabIndex = 0;
            btnCreateUser.Text = "Создать пользователя";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // pnlLoading
            // 
            pnlLoading.ColumnCount = 1;
            pnlLoading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlLoading.Controls.Add(progressBar, 0, 0);
            pnlLoading.Dock = DockStyle.Fill;
            pnlLoading.Location = new Point(0, 40);
            pnlLoading.Name = "pnlLoading";
            pnlLoading.RowCount = 1;
            pnlLoading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlLoading.Size = new Size(969, 410);
            pnlLoading.TabIndex = 2;
            pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.None;
            progressBar.Location = new Point(384, 195);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(200, 20);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 450);
            Controls.Add(gridUsers);
            Controls.Add(pnlLoading);
            Controls.Add(panelTop);
            Name = "UsersForm";
            Text = "Users";
            Load += UsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            panelTop.ResumeLayout(false);
            pnlLoading.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
