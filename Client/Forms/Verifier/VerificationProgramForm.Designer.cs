namespace PoverkaWinForms.Forms.Verifier
{
    partial class VerificationProgramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            HeaderLabel = new Label();
            ProgramDataGridView = new DataGridView();
            ParameterColumn = new DataGridViewTextBoxColumn();
            Place1Column = new DataGridViewTextBoxColumn();
            Place2Column = new DataGridViewTextBoxColumn();
            Place3Column = new DataGridViewTextBoxColumn();
            Place4Column = new DataGridViewTextBoxColumn();
            Place5Column = new DataGridViewTextBoxColumn();
            Place6Column = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ProgramDataGridView).BeginInit();
            SuspendLayout();
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            HeaderLabel.Location = new Point(12, 20);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(264, 31);
            HeaderLabel.TabIndex = 0;
            HeaderLabel.Text = "Программа поверки";
            // 
            // ProgramDataGridView
            // 
            ProgramDataGridView.AllowUserToAddRows = false;
            ProgramDataGridView.AllowUserToDeleteRows = false;
            ProgramDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProgramDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProgramDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProgramDataGridView.Columns.AddRange(new DataGridViewColumn[] { ParameterColumn, Place1Column, Place2Column, Place3Column, Place4Column, Place5Column, Place6Column });
            ProgramDataGridView.Location = new Point(12, 70);
            ProgramDataGridView.Name = "ProgramDataGridView";
            ProgramDataGridView.ReadOnly = true;
            ProgramDataGridView.RowHeadersVisible = false;
            ProgramDataGridView.Size = new Size(1134, 646);
            ProgramDataGridView.TabIndex = 1;
            // 
            // ParameterColumn
            // 
            ParameterColumn.HeaderText = "Наименование";
            ParameterColumn.Name = "ParameterColumn";
            ParameterColumn.ReadOnly = true;
            ParameterColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Place1Column
            // 
            Place1Column.HeaderText = "Место 1";
            Place1Column.Name = "Place1Column";
            Place1Column.ReadOnly = true;
            Place1Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Place2Column
            // 
            Place2Column.HeaderText = "Место 2";
            Place2Column.Name = "Place2Column";
            Place2Column.ReadOnly = true;
            Place2Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Place3Column
            // 
            Place3Column.HeaderText = "Место 3";
            Place3Column.Name = "Place3Column";
            Place3Column.ReadOnly = true;
            Place3Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Place4Column
            // 
            Place4Column.HeaderText = "Место 4";
            Place4Column.Name = "Place4Column";
            Place4Column.ReadOnly = true;
            Place4Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Place5Column
            // 
            Place5Column.HeaderText = "Место 5";
            Place5Column.Name = "Place5Column";
            Place5Column.ReadOnly = true;
            Place5Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Place6Column
            // 
            Place6Column.HeaderText = "Место 6";
            Place6Column.Name = "Place6Column";
            Place6Column.ReadOnly = true;
            Place6Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // VerificationProgramForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 728);
            Controls.Add(ProgramDataGridView);
            Controls.Add(HeaderLabel);
            Name = "VerificationProgramForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Программа поверки";
            Load += VerificationProgramForm_Load;
            ((System.ComponentModel.ISupportInitialize)ProgramDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HeaderLabel;
        private DataGridView ProgramDataGridView;
        private DataGridViewTextBoxColumn ParameterColumn;
        private DataGridViewTextBoxColumn Place1Column;
        private DataGridViewTextBoxColumn Place2Column;
        private DataGridViewTextBoxColumn Place3Column;
        private DataGridViewTextBoxColumn Place4Column;
        private DataGridViewTextBoxColumn Place5Column;
        private DataGridViewTextBoxColumn Place6Column;
    }
}
