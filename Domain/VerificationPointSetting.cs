namespace PoverkaWinForms.Domain
{
    public class VerificationPointSetting
    {
        public int Id { get; set; }
        public string? Diameter { get; set; }
        public decimal? MaxFlow { get; set; }
        public decimal? FlowPercentOfMax { get; set; }
        public decimal? TestFlow { get; set; }
        public int? TestTime { get; set; }
        public decimal? ImpulseWeightImpPerL { get; set; }
        public decimal? ImpulseWeightLPerImp { get; set; }
        public decimal? ImpulseWeightM3PerImp { get; set; }
        public decimal? RelativeError { get; set; }
    }
}
