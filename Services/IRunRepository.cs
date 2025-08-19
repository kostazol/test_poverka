using System.Collections.Generic;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public interface IRunRepository
    {
        List<TestRun> GetAll();
        List<TestRun> GetBySerial(string serial);
        void Add(TestRun run);
        void ReplaceAll(List<TestRun> runs);
    }
}
