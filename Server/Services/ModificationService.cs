using Microsoft.EntityFrameworkCore;
using PoverkaServer.Data;
using PoverkaServer.Domain;

namespace PoverkaServer.Services;

public class ModificationService
{
    private readonly ApplicationDbContext _db;

    public ModificationService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<List<Modification>> GetAllAsync() => _db.Modifications.ToListAsync();

    public Task<Modification?> GetAsync(int id) => _db.Modifications.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Modification> CreateAsync(string editorName, int registrationId, string className, double impulseWeight, double qmin, double qt1, double qt2, double qmax, double checkpoint1, double checkpoint2, double checkpoint3, double? checkpoint4, byte numberOfMeasurements, short minPulseCount, short measurementDurationInSeconds, byte relativeErrorWithStandartValue)
    {
        var modification = new Modification(editorName, registrationId, className, impulseWeight, qmin, qt1, qt2, qmax, checkpoint1, checkpoint2, checkpoint3, checkpoint4, numberOfMeasurements, minPulseCount, measurementDurationInSeconds, relativeErrorWithStandartValue);
        _db.Modifications.Add(modification);
        await _db.SaveChangesAsync();
        return modification;
    }

    public async Task<bool> UpdateAsync(int id, string editorName, int registrationId, string className, double impulseWeight, double qmin, double qt1, double qt2, double qmax, double checkpoint1, double checkpoint2, double checkpoint3, double? checkpoint4, byte numberOfMeasurements, short minPulseCount, short measurementDurationInSeconds, byte relativeErrorWithStandartValue)
    {
        var modification = await _db.Modifications.FindAsync(id);
        if (modification is null)
            return false;
        modification.Update(editorName, registrationId, className, impulseWeight, qmin, qt1, qt2, qmax, checkpoint1, checkpoint2, checkpoint3, checkpoint4, numberOfMeasurements, minPulseCount, measurementDurationInSeconds, relativeErrorWithStandartValue);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var modification = await _db.Modifications.FindAsync(id);
        if (modification is not null)
        {
            _db.Modifications.Remove(modification);
            await _db.SaveChangesAsync();
        }
    }
}
