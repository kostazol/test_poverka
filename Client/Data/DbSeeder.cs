using System.Linq;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.StateRegisters.Any())
            {
                return;
            }

            var state = new StateRegister("A-1", "Sample Instrument", "Doc1");
            var diameter = new Diameter { Value = 100, StateRegister = state };
            var modification = new FlowmeterModification { Modification = "FM-100", StateRegister = state };
            var parameter = new ParameterSetting
            {
                RegisterNumber = "A-1",
                SerialNumber = "SN123",
                InstrumentName = "Sample Instrument",
                VerificationDocument = "Doc1",
                Modification = "FM-100"
            };
            var verificationPoint = new VerificationPointSetting
            {
                Diameter = "100",
                MaxFlow = 1000m,
                FlowPercentOfMax = 50m,
                TestFlow = 500m,
                TestTime = 60,
                ImpulseWeightImpPerL = 1m,
                ImpulseWeightLPerImp = 1m,
                ImpulseWeightM3PerImp = 1m,
                RelativeError = 0.1m
            };

            context.StateRegisters.Add(state);
            context.Diameters.Add(diameter);
            context.FlowmeterModifications.Add(modification);
            context.ParameterSettings.Add(parameter);
            context.VerificationPointSettings.Add(verificationPoint);

            context.SaveChanges();
        }
    }
}
