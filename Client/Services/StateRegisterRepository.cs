using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PoverkaWinForms.Data;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public class StateRegisterRepository : IStateRegisterRepository
    {
        private readonly AppDbContext _db;

        public StateRegisterRepository(AppDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public List<StateRegister> GetAll()
        {
            return _db.StateRegisters.AsNoTracking().ToList();
        }

        public StateRegister? GetByRegisterNumber(string registerNumber)
        {
            return _db.StateRegisters.AsNoTracking()
                .FirstOrDefault(r => r.RegisterNumber == registerNumber);
        }
    }
}
