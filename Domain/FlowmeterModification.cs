namespace PoverkaWinForms.Domain
{
    public class FlowmeterModification
    {
        public string Modification { get; set; } = "";
        public int? StateRegisterId { get; set; }

        public StateRegister? StateRegister { get; set; }
    }
}
