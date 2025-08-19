namespace PoverkaWinForms.Domain
{
    public class Meter
    {
        public string Serial { get; set; } = "";
        public string Model { get; set; } = "";
        public double DiameterMm { get; set; }
        public string Unit { get; set; } = "m3/h";
    }
}
