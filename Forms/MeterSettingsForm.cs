using System.Drawing;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms
{
    /// <summary>
    /// Form with settings for up to six flow meters.
    /// </summary>
    public class MeterSettingsForm : Form
    {
        public MeterSettingsForm()
        {
            Text = "Настройка параметров поверяемых преобразователей";
            ClientSize = new Size(930, 560);
            StartPosition = FormStartPosition.CenterScreen;

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60
            };
            Controls.Add(header);

            var lblTitle = new Label
            {
                Text = "Настройка параметров поверяемых преобразователей",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point)
            };
            header.Controls.Add(lblTitle);

            var btnTest = new Button
            {
                Text = "Тест",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(header.Width - 80, 15)
            };
            header.Controls.Add(btnTest);

            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 2,
                Padding = new Padding(10)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            Controls.Add(table);

            for (int i = 0; i < 6; i++)
            {
                var control = new MeterConfigControl
                {
                    Text = $"Расходомер №{i + 1}",
                    Dock = DockStyle.Fill,
                    Margin = new Padding(6)
                };
                table.Controls.Add(control, i % 3, i / 3);
            }
        }
    }
}

