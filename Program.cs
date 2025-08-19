using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using PoverkaWinForms.Services;

namespace PoverkaWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            services.AddSingleton<IRunRepository>(_ =>
            {
                string dataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Poverka", "data.json");
                return new JsonRepository(dataPath);
            });
            services.AddSingleton<MainForm>();

            using var provider = services.BuildServiceProvider();
            Application.Run(provider.GetRequiredService<MainForm>());
        }
    }
}
