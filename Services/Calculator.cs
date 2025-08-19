using System;

namespace PoverkaWinForms.Services
{
    public static class Calculator
    {
        /// <summary>
        /// Calculates actual flow in L/s based on measured volume and time.
        /// Applies simple temperature correction for water density (very rough).
        /// </summary>
        public static double CalculateActualFlow(double volumeLiters, double timeSeconds, double temperatureC)
        {
            if (timeSeconds <= 0) return 0;
            var flow = volumeLiters / timeSeconds; // L/s

            // Very rough density correction around 4..30C (optional, placeholder)
            // rho_rel ≈ 1 - 0.0003*(T-4). We *increase* flow a tiny bit at higher T to emulate expansion
            var correction = 1.0 + 0.0003 * (temperatureC - 4.0);
            return flow * correction;
        }

        public static double CalculateErrorPercent(double indicatedFlow, double actualFlow)
        {
            if (actualFlow == 0) return 0;
            return (indicatedFlow - actualFlow) / actualFlow * 100.0;
        }
    }
}
