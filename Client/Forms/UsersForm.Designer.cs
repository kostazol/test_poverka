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
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnChangeMyPassword = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.pnlLoading = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.panelTop.SuspendLayout();
            this.pnlLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnChangeMyPassword);
            this.panelTop.Controls.Add(this.btnChangePassword);
            this.panelTop.Controls.Add(this.btnEditUser);
            this.panelTop.Controls.Add(this.btnCreateUser);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 40);
            this.panelTop.TabIndex = 0;
            // 
            // btnChangeMyPassword
            // 
            this.btnChangeMyPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnChangeMyPassword.Location = new System.Drawing.Point(638, 7);
            this.btnChangeMyPassword.Name = "btnChangeMyPassword";
            this.btnChangeMyPassword.Size = new System.Drawing.Size(150, 29);
            this.btnChangeMyPassword.TabIndex = 3;
            this.btnChangeMyPassword.Text = "Изменить свой пароль";
            this.btnChangeMyPassword.UseVisualStyleBackColor = true;
            this.btnChangeMyPassword.Click += new System.EventHandler(this.btnChangeMyPassword_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Enabled = false;
            this.btnChangePassword.Location = new System.Drawing.Point(324, 7);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(150, 29);
            this.btnChangePassword.TabIndex = 2;
            this.btnChangePassword.Text = "Изменить пароль";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Location = new System.Drawing.Point(168, 7);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(150, 29);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "Изменить пользователя";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(12, 7);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(150, 29);
            this.btnCreateUser.TabIndex = 0;
            this.btnCreateUser.Text = "Создать пользователя";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // gridUsers
            // 
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsers.Location = new System.Drawing.Point(0, 40);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersWidth = 51;
            this.gridUsers.RowTemplate.Height = 29;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(800, 410);
            this.gridUsers.TabIndex = 1;
            this.gridUsers.SelectionChanged += new System.EventHandler(this.gridUsers_SelectionChanged);
            // 
            // pnlLoading
            // 
            this.pnlLoading.ColumnCount = 1;
            this.pnlLoading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLoading.Controls.Add(this.progressBar, 0, 0);
            this.pnlLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoading.Location = new System.Drawing.Point(0, 40);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.RowCount = 1;
            this.pnlLoading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLoading.Size = new System.Drawing.Size(800, 410);
            this.pnlLoading.TabIndex = 2;
            this.pnlLoading.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(300, 195);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.panelTop);
            this.Name = "UsersForm";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.pnlLoading.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
