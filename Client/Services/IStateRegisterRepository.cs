using System.Collections.Generic;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public interface IStateRegisterRepository
    {
        List<StateRegister> GetAll();
        StateRegister? GetByRegisterNumber(string registerNumber);
    }
}
