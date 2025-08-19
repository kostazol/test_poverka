using System;
using System.IO;
using System.Text;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public static class ReportGenerator
    {
        public static string GenerateRtf(TestRun run)
        {
            // A tiny RTF template (Cyrillic supported via \ansi\ansicpg1251)
            string rtf = @"{\rtf1\ansi\ansicpg1251\deff0
{\fonttbl{\f0 Arial;}}
\fs20 Поверка расходомера\par
Дата: " + run.Timestamp.ToString("yyyy-MM-dd HH:mm") + @"\par
Серийный номер: " + Escape(run.Meter.Serial) + @"\par
Модель: " + Escape(run.Meter.Model) + @"\par
Диаметр: " + run.Meter.DiameterMm + @" мм\par
\par
Измеренный объём: " + run.VolumeLiters.ToString("0.###") + @" л\par
Время пролива: " + run.TimeSeconds.ToString("0.###") + @" с\par
Температура: " + run.TemperatureC.ToString("0.#") + @" °C\par
Давление: " + run.PressureKPa.ToString("0.#") + @" кПа\par
\par
Поток по прибору: " + run.IndicatedFlow.ToString("0.###") + @" л/с\par
Действительный поток: " + run.ActualFlow.ToString("0.###") + @" л/с\par
Погрешность: " + run.ErrorPercent.ToString("0.###") + @" %\par
\par
Подпись оператора: ______________________\par
}";
            return rtf;
        }

        public static string SaveRtfTo(string dir, TestRun run)
        {
            Directory.CreateDirectory(dir);
            string fileName = $"Report_{run.Timestamp:yyyyMMdd_HHmm}_{Sanitize(run.Meter.Serial)}.rtf";
            string path = Path.Combine(dir, fileName);
            File.WriteAllText(path, GenerateRtf(run), Encoding.GetEncoding(1251));
            return path;
        }

        private static string Sanitize(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return string.IsNullOrWhiteSpace(name) ? "meter" : name;
        }

        private static string Escape(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
        }
    }
}
