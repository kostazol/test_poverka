using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoverkaWinForms
{
    public class MetersSetupForm : Form
    {
        public MetersSetupForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Настройка параметров поверяемых преобразователей";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(980, 600);

            var lblTitle = new Label
            {
                Text = "Настройка параметров поверяемых преобразователей",
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold)
            };
            Controls.Add(lblTitle);

            var btnTest = new Button
            {
                Text = "Тест",
                Size = new Size(75, 30),
                Location = new Point(ClientSize.Width - 85, 45),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            Controls.Add(btnTest);

            string[] labels = { "Производитель", "Тип", "Заводской номер", "Заводской номер СИ", "Заводской номер рс", "Документ на поверку" };
            int groupWidth = 300;
            int groupHeight = 200;
            int margin = 10;
            for (int i = 0; i < 6; i++)
            {
                var grp = new GroupBox
                {
                    Text = $"Расходомер №{i + 1}",
                    Size = new Size(groupWidth, groupHeight)
                };
                int row = i / 3;
                int col = i % 3;
                grp.Location = new Point(margin + (groupWidth + margin) * col,
                    80 + (groupHeight + margin) * row);

                var chk = new CheckBox
                {
                    Text = "Включить",
                    AutoSize = true,
                    Location = new Point(grp.Width - 80, 0)
                };
                grp.Controls.Add(chk);

                for (int l = 0; l < labels.Length; l++)
                {
                    var lbl = new Label
                    {
                        Text = labels[l],
                        Location = new Point(10, 25 + l * 28),
                        AutoSize = true
                    };
                    var txt = new TextBox
                    {
                        Location = new Point(150, 22 + l * 28),
                        Width = 130
                    };
                    grp.Controls.Add(lbl);
                    grp.Controls.Add(txt);
                }

                Controls.Add(grp);
            }

            var btnInput = new Button
            {
                Text = "Ввод",
                Size = new Size(75, 30),
                Location = new Point(margin, ClientSize.Height - 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            Controls.Add(btnInput);

            var btnExit = new Button
            {
                Text = "Выход",
                Size = new Size(75, 30),
                Location = new Point(ClientSize.Width - 85, ClientSize.Height - 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnExit.Click += (_, _) => Close();
            Controls.Add(btnExit);
        }
    }
}

