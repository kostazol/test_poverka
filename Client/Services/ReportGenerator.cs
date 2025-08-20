using System;
using System.IO;
using System.Text;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public static class ReportGenerator
    {
        private const string TemplateFile = "Reports/DefaultReport.rtf";

        public static string GenerateRtf(TestRun run, string? templatePath = null)
        {
            templatePath ??= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TemplateFile);

            string template = File.ReadAllText(templatePath, Encoding.GetEncoding(1251));

            string rtf = template
                .Replace("{{Date}}", run.Timestamp.ToString("yyyy-MM-dd HH:mm"))
                .Replace("{{Serial}}", Escape(run.Meter.Serial))
                .Replace("{{Model}}", Escape(run.Meter.Model))
                .Replace("{{Diameter}}", run.Meter.DiameterMm.ToString())
                .Replace("{{Volume}}", run.VolumeLiters.ToString("0.###"))
                .Replace("{{Time}}", run.TimeSeconds.ToString("0.###"))
                .Replace("{{Temperature}}", run.TemperatureC.ToString("0.#"))
                .Replace("{{Pressure}}", run.PressureKPa.ToString("0.#"))
                .Replace("{{IndicatedFlow}}", run.IndicatedFlow.ToString("0.###"))
                .Replace("{{ActualFlow}}", run.ActualFlow.ToString("0.###"))
                .Replace("{{ErrorPercent}}", run.ErrorPercent.ToString("0.###"));

            return rtf;
        }

        public static string SaveRtfTo(string dir, TestRun run, string? templatePath = null)
        {
            Directory.CreateDirectory(dir);
            string fileName = $"Report_{run.Timestamp:yyyyMMdd_HHmm}_{Sanitize(run.Meter.Serial)}.rtf";
            string path = Path.Combine(dir, fileName);
            File.WriteAllText(path, GenerateRtf(run, templatePath), Encoding.GetEncoding(1251));
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
