using System.Collections.Generic;

namespace PoverkaWinForms.Domain
{
    public class StateRegister
    {
        public int Id { get; set; }
        public string RegisterNumber { get; set; }
        public string InstrumentName { get; set; }
        public string VerificationDocument { get; set; }

        public List<Diameter> Diameters { get; set; } = new();
        public List<FlowmeterModification> FlowmeterModifications { get; set; } = new();

        public StateRegister(string registerNumber, string instrumentName, string verificationDocument)
        {
            RegisterNumber = registerNumber;
            InstrumentName = instrumentName;
            VerificationDocument = verificationDocument;
        }

#pragma warning disable CS8618
        private StateRegister()
        {
        }
#pragma warning restore CS8618
    }
}
