using System.Collections.Generic;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public interface IRunRepository
    {
        List<TestRun> GetAll();
        void Add(TestRun run);
        void ReplaceAll(List<TestRun> runs);
    }
}
