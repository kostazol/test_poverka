namespace PoverkaWinForms.Forms.Admin
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnChangeMyPassword;
        private System.Windows.Forms.TableLayoutPanel pnlLoading;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtCsvPath;
        private System.Windows.Forms.Button btnAddFromFile;
        private System.Windows.Forms.Button btnProcessFile;

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
            tabControl = new TabControl();
            tabUsers = new TabPage();
            gridUsers = new DataGridView();
            pnlLoading = new TableLayoutPanel();
            progressBar = new ProgressBar();
            panelTop = new Panel();
            btnChangeMyPassword = new Button();
            btnChangePassword = new Button();
            btnEditUser = new Button();
            btnCreateUser = new Button();
            tabSettings = new TabPage();
            txtCsvPath = new TextBox();
            btnAddFromFile = new Button();
            btnProcessFile = new Button();
            tabControl.SuspendLayout();
            tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            pnlLoading.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            //
            // tabControl
            //
            tabControl.Controls.Add(tabUsers);
            tabControl.Controls.Add(tabSettings);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(969, 450);
            tabControl.TabIndex = 0;
            //
            // tabUsers
            //
            tabUsers.Controls.Add(gridUsers);
            tabUsers.Controls.Add(pnlLoading);
            tabUsers.Controls.Add(panelTop);
            tabUsers.Location = new Point(4, 29);
            tabUsers.Name = "tabUsers";
            tabUsers.Padding = new Padding(3);
            tabUsers.Size = new Size(961, 417);
            tabUsers.TabIndex = 0;
            tabUsers.Text = "Пользователи";
            tabUsers.UseVisualStyleBackColor = true;
            //
            // gridUsers
            //
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Dock = DockStyle.Fill;
            gridUsers.Location = new Point(3, 43);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.RowHeadersWidth = 51;
            gridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new Size(955, 371);
            gridUsers.TabIndex = 1;
            gridUsers.SelectionChanged += gridUsers_SelectionChanged;
            //
            // pnlLoading
            //
            pnlLoading.ColumnCount = 1;
            pnlLoading.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlLoading.Controls.Add(progressBar, 0, 0);
            pnlLoading.Dock = DockStyle.Fill;
            pnlLoading.Location = new Point(3, 43);
            pnlLoading.Name = "pnlLoading";
            pnlLoading.RowCount = 1;
            pnlLoading.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlLoading.Size = new Size(955, 371);
            pnlLoading.TabIndex = 2;
            pnlLoading.Visible = false;
            //
            // progressBar
            //
            progressBar.Anchor = AnchorStyles.None;
            progressBar.Location = new Point(377, 175);
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(200, 20);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            //
            // panelTop
            //
            panelTop.Controls.Add(btnChangeMyPassword);
            panelTop.Controls.Add(btnChangePassword);
            panelTop.Controls.Add(btnEditUser);
            panelTop.Controls.Add(btnCreateUser);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(955, 40);
            panelTop.TabIndex = 0;
            //
            // btnChangeMyPassword
            //
            btnChangeMyPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeMyPassword.Location = new Point(751, 7);
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
            // tabSettings
            //
            tabSettings.Controls.Add(btnProcessFile);
            tabSettings.Controls.Add(btnAddFromFile);
            tabSettings.Controls.Add(txtCsvPath);
            tabSettings.Location = new Point(4, 29);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new Padding(3);
            tabSettings.Size = new Size(961, 417);
            tabSettings.TabIndex = 1;
            tabSettings.Text = "Настройки";
            tabSettings.UseVisualStyleBackColor = true;
            //
            // txtCsvPath
            //
            txtCsvPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCsvPath.Location = new Point(8, 8);
            txtCsvPath.Name = "txtCsvPath";
            txtCsvPath.ReadOnly = true;
            txtCsvPath.Size = new Size(760, 27);
            txtCsvPath.TabIndex = 0;
            //
            // btnAddFromFile
            //
            btnAddFromFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddFromFile.Location = new Point(774, 6);
            btnAddFromFile.Name = "btnAddFromFile";
            btnAddFromFile.Size = new Size(175, 29);
            btnAddFromFile.TabIndex = 1;
            btnAddFromFile.Text = "Добавить из файла";
            btnAddFromFile.UseVisualStyleBackColor = true;
            btnAddFromFile.Click += btnAddFromFile_Click;
            //
            // btnProcessFile
            //
            btnProcessFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProcessFile.Location = new Point(774, 41);
            btnProcessFile.Name = "btnProcessFile";
            btnProcessFile.Size = new Size(175, 29);
            btnProcessFile.TabIndex = 2;
            btnProcessFile.Text = "Обработать";
            btnProcessFile.UseVisualStyleBackColor = true;
            btnProcessFile.Click += btnProcessFile_Click;
            //
            // ConfigurationForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 450);
            Controls.Add(tabControl);
            Name = "ConfigurationForm";
            Text = "Configuration";
            Load += ConfigurationForm_Load;
            tabControl.ResumeLayout(false);
            tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            pnlLoading.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
