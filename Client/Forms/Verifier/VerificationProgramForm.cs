using System;
using System.Windows.Forms;

namespace PoverkaWinForms.Forms.Verifier
{
    public partial class VerificationProgramForm : Form
    {
        public VerificationProgramForm()
        {
            InitializeComponent();
        }

        private void VerificationProgramFormLoad(object? sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ProgramDataGridView.Rows.Add("Полное наименование", "Расходомеры-счетчики электромагнитные", "", "Преобразователи расхода электромагнитные", "", "", "");
            ProgramDataGridView.Rows.Add("Тип", "ПИТЕРФЛОУ", "ПИТЕРФЛОУ", "ПРЭМ", "ПРЭМ", "", "");
            ProgramDataGridView.Rows.Add("Модификация", "РС20-12-С-С", "РС20-12-С-С", "Ду20, класс В1", "Ду20, класс В1", "", "");
            ProgramDataGridView.Rows.Add("Номер госреестра СИ", "66324-16", "66324-16", "76327-19", "76327-19", "", "");
            ProgramDataGridView.Rows.Add("Межповерочный интервал (месяцев)", "48", "48", "48", "48", "", "");
            ProgramDataGridView.Rows.Add("Межповерочный интервал", "4 года", "4 года", "4 года", "4 года", "", "");
            ProgramDataGridView.Rows.Add("Изготовитель", "Термотроник", "Термотроник", "ИВТрейд", "ИВТрейд", "", "");
            ProgramDataGridView.Rows.Add("Режим поверки V, м3", "да", "да", "да", "да", "", "");
            ProgramDataGridView.Rows.Add("Режим поверки Q, м3", "да", "да", "нет", "нет", "", "");
            ProgramDataGridView.Rows.Add("Вес импульса, л/имп", "0,25", "0,25", "0,50", "0,5", "", "");
            ProgramDataGridView.Rows.Add("Измеренный вес импульса", "0,0005", "0,0005", "0,0005000", "0,0005", "", "");
            ProgramDataGridView.Rows.Add("Кол-во импульсов (требуемое)", "500", "500", "1000", "1000", "", "");
            ProgramDataGridView.Rows.Add("Время поверки, с", "60", "60", "60", "60", "", "");
            ProgramDataGridView.Rows.Add("Qmax", "12", "12", "12", "12", "", "");
            ProgramDataGridView.Rows.Add("Методика поверки", "Инструкция. ГСИ. Расходомеры-счетчики электромагнитные ПИТЕРФЛОУ. Методика поверки. МП 0470-1-2016", "Инструкция. ГСИ. Расходомеры-счетчики электромагнитные ПИТЕРФЛОУ. Методика поверки. МП 0470-1-2016", "ГСОЕИ. Преобразователи расхода электромагнитные ПРЭМ ТНРВ.407111.039 МП", "ГСОЕИ. Преобразователи расхода электромагнитные ПРЭМ ТНРВ.407111.039 МП", "", "");
        }
    }
}
