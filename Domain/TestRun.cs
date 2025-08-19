using System;

namespace PoverkaWinForms.Domain
{
    public class TestRun
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public Meter Meter { get; set; } = new Meter();

        // Inputs
        public double VolumeLiters { get; set; }
        public double TimeSeconds { get; set; }
        public double IndicatedFlow { get; set; } // from DUT (device under test)
        public double TemperatureC { get; set; }
        public double PressureKPa { get; set; }

        // Calculated
        public double ActualFlow { get; set; }    // L/s
        public double ErrorPercent { get; set; }
    }
}
