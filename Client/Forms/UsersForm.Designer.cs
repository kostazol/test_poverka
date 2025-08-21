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
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.Controls.Add(this.btnEditUser);
            this.panelTop.Controls.Add(this.btnCreateUser);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 40);
            this.panelTop.TabIndex = 0;
            //
            // btnCreateUser
            //
            this.btnCreateUser.Location = new System.Drawing.Point(12, 7);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(150, 29);
            this.btnCreateUser.TabIndex = 0;
            this.btnCreateUser.Text = "Создать пользователя";
            this.btnCreateUser.UseVisualStyleBackColor = true;
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
            //
            // gridUsers
            //
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUsers.Location = new System.Drawing.Point(0, 40);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersWidth = 51;
            this.gridUsers.RowTemplate.Height = 29;
            this.gridUsers.Size = new System.Drawing.Size(800, 410);
            this.gridUsers.TabIndex = 1;
            this.gridUsers.SelectionChanged += new System.EventHandler(this.gridUsers_SelectionChanged);
            //
            // UsersForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.panelTop);
            this.Name = "UsersForm";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
