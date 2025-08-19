using System.Drawing;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms
{
    /// <summary>
    /// Control for entering settings of a single flow meter.
    /// </summary>
    public class MeterConfigControl : GroupBox
    {
        private readonly CheckBox _chkEnabled;
        private readonly TableLayoutPanel _layout;

        public MeterConfigControl()
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Size = new Size(250, 170);

            _chkEnabled = new CheckBox
            {
                Text = "Включить",
                AutoSize = true,
                Checked = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(Width - 85, -2)
            };
            Controls.Add(_chkEnabled);

            _layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 5,
                Dock = DockStyle.Fill,
                Location = new Point(3, 19),
                Padding = new Padding(3),
            };

            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            for (int i = 0; i < 5; i++)
            {
                _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            }

            AddField("Производитель", out var txtMan);
            AddField("Тип", out var txtType);
            AddField("Заводской номер", out var txtSerial);
            AddField("Методика СИ", out var txtMethod);
            AddField("Документ на поверку", out var txtDoc);

            Controls.Add(_layout);

            _chkEnabled.CheckedChanged += (_, _) => _layout.Enabled = _chkEnabled.Checked;
        }

        private void AddField(string label, out TextBox box)
        {
            var lbl = new Label
            {
                Text = label,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            box = new TextBox { Dock = DockStyle.Fill };
            int row = _layout.Controls.Count / 2;
            _layout.Controls.Add(lbl, 0, row);
            _layout.Controls.Add(box, 1, row);
        }
    }
}

