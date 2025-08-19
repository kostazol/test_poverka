namespace PoverkaWinForms.Domain
{
    public class Diameter
    {
        public int Id { get; set; }
        public int? StateRegisterId { get; set; }
        public int Value { get; set; }

        public StateRegister? StateRegister { get; set; }
    }
}
