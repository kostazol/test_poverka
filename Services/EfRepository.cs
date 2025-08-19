using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PoverkaWinForms.Data;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public class EfRepository : IRunRepository, IDisposable
    {
        private readonly AppDbContext _db;

        public EfRepository(AppDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public List<TestRun> GetAll()
        {
            return _db.TestRuns.AsNoTracking()
                .OrderByDescending(r => r.Timestamp)
                .ToList();
        }

        public void Add(TestRun run)
        {
            _db.TestRuns.Add(run);
            _db.SaveChanges();
        }

        public void ReplaceAll(List<TestRun> runs)
        {
            using var trx = _db.Database.BeginTransaction();
            _db.TestRuns.RemoveRange(_db.TestRuns);
            _db.SaveChanges();
            _db.TestRuns.AddRange(runs);
            _db.SaveChanges();
            trx.Commit();
        }

        public void Dispose() => _db.Dispose();
    }
}
