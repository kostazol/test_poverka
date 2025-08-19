using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using PoverkaWinForms.Domain;

namespace PoverkaWinForms.Services
{
    public class JsonRepository : IRunRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _opts = new JsonSerializerOptions { WriteIndented = true };

        public JsonRepository(string path)
        {
            _path = path;
            var dir = Path.GetDirectoryName(_path);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir!);
        }

        public List<TestRun> GetAll()
        {
            if (!File.Exists(_path)) return new List<TestRun>();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<TestRun>>(json) ?? new List<TestRun>();
        }

        public List<TestRun> GetBySerial(string serial)
        {
            return GetAll()
                .Where(r => r.Meter.Serial == serial)
                .OrderByDescending(r => r.Timestamp)
                .ToList();
        }

        public void ReplaceAll(List<TestRun> runs)
        {
            SaveAllInternal(runs);
        }

        public void Add(TestRun run)
        {
            var runs = GetAll();
            runs.Add(run);
            SaveAllInternal(runs);
        }

        private void SaveAllInternal(List<TestRun> runs)
        {
            var json = JsonSerializer.Serialize(runs, _opts);
            File.WriteAllText(_path, json);
        }
    }
}
