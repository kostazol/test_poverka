using Microsoft.EntityFrameworkCore;
using PoverkaServer.Data;
using PoverkaServer.Domain;

namespace PoverkaServer.Services;

public record ModificationWithRegistrationNumber(Modification Modification, string RegistrationNumber);

public class ModificationService
{
    private readonly ApplicationDbContext _db;

    public ModificationService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<List<ModificationWithRegistrationNumber>> GetAllAsync() =>
        _db.Modifications
            .Join(
                _db.Registrations,
                m => m.RegistrationId,
                r => r.Id,
                (m, r) => new ModificationWithRegistrationNumber(m, r.RegistrationNumber)
            )
            .ToListAsync();

    public Task<List<ModificationWithRegistrationNumber>> GetFilteredAsync(int meterTypeId, string manufacturerName, DateOnly manufactureDate) =>
        _db.Modifications
            .Join(
                _db.Registrations,
                m => m.RegistrationId,
                r => r.Id,
                (m, r) => new { m, r }
            )
            .Join(
                _db.MeterTypes,
                mr => mr.r.MeterTypeId,
                mt => mt.Id,
                (mr, mt) => new { mr.m, mr.r, mt }
            )
            .Where(x =>
                x.mt.Id == meterTypeId
                && x.mt.ManufacturerName == manufacturerName
                && x.r.RegistrationDate <= manufactureDate
                && x.r.EndDate >= manufactureDate
            )
            .Select(x => new ModificationWithRegistrationNumber(x.m, x.r.RegistrationNumber))
            .ToListAsync();

    public Task<ModificationWithRegistrationNumber?> GetAsync(int id) =>
        _db.Modifications
            .Join(
                _db.Registrations,
                m => m.RegistrationId,
                r => r.Id,
                (m, r) => new { m, r }
            )
            .Where(x => x.m.Id == id)
            .Select(x => new ModificationWithRegistrationNumber(x.m, x.r.RegistrationNumber))
            .FirstOrDefaultAsync();

    public async Task<Modification> CreateAsync(
        string editorName,
        int registrationId,
        string name,
        string className,
        double pasportImpulseWeight,
        double verificationImpulseWeight,
        double qmin,
        double qt1,
        double qt2,
        double qmax,
        double checkpoint1,
        double checkpoint1RequiredTime,
        double checkpoint1TimeMultiplier,
        double checkpoint1PulseCount,
        double checkpoint2,
        double checkpoint2RequiredTime,
        double checkpoint2TimeMultiplier,
        double checkpoint2PulseCount,
        double checkpoint3,
        double checkpoint3RequiredTime,
        double checkpoint3TimeMultiplier,
        double checkpoint3PulseCount,
        double? checkpoint4,
        double? checkpoint4RequiredTime,
        double? checkpoint4TimeMultiplier,
        double? checkpoint4PulseCount,
        byte numberOfMeasurements,
        short minPulseCount,
        short measurementDurationInSeconds,
        double flowSetpointPercent)
    {
        var modification = new Modification(
            editorName,
            registrationId,
            name,
            className,
            pasportImpulseWeight,
            verificationImpulseWeight,
            qmin,
            qt1,
            qt2,
            qmax,
            checkpoint1,
            checkpoint1RequiredTime,
            checkpoint1TimeMultiplier,
            checkpoint1PulseCount,
            checkpoint2,
            checkpoint2RequiredTime,
            checkpoint2TimeMultiplier,
            checkpoint2PulseCount,
            checkpoint3,
            checkpoint3RequiredTime,
            checkpoint3TimeMultiplier,
            checkpoint3PulseCount,
            checkpoint4,
            checkpoint4RequiredTime,
            checkpoint4TimeMultiplier,
            checkpoint4PulseCount,
            numberOfMeasurements,
            minPulseCount,
            measurementDurationInSeconds,
            flowSetpointPercent);
        _db.Modifications.Add(modification);
        await _db.SaveChangesAsync();
        return modification;
    }

    public async Task<bool> UpdateAsync(
        int id,
        string editorName,
        int registrationId,
        string name,
        string className,
        double pasportImpulseWeight,
        double verificationImpulseWeight,
        double qmin,
        double qt1,
        double qt2,
        double qmax,
        double checkpoint1,
        double checkpoint1RequiredTime,
        double checkpoint1TimeMultiplier,
        double checkpoint1PulseCount,
        double checkpoint2,
        double checkpoint2RequiredTime,
        double checkpoint2TimeMultiplier,
        double checkpoint2PulseCount,
        double checkpoint3,
        double checkpoint3RequiredTime,
        double checkpoint3TimeMultiplier,
        double checkpoint3PulseCount,
        double? checkpoint4,
        double? checkpoint4RequiredTime,
        double? checkpoint4TimeMultiplier,
        double? checkpoint4PulseCount,
        byte numberOfMeasurements,
        short minPulseCount,
        short measurementDurationInSeconds,
        double flowSetpointPercent)
    {
        var modification = await _db.Modifications.FindAsync(id);
        if (modification is null)
        {
            return false;
        }
        modification.Update(
            editorName,
            registrationId,
            name,
            className,
            pasportImpulseWeight,
            verificationImpulseWeight,
            qmin,
            qt1,
            qt2,
            qmax,
            checkpoint1,
            checkpoint1RequiredTime,
            checkpoint1TimeMultiplier,
            checkpoint1PulseCount,
            checkpoint2,
            checkpoint2RequiredTime,
            checkpoint2TimeMultiplier,
            checkpoint2PulseCount,
            checkpoint3,
            checkpoint3RequiredTime,
            checkpoint3TimeMultiplier,
            checkpoint3PulseCount,
            checkpoint4,
            checkpoint4RequiredTime,
            checkpoint4TimeMultiplier,
            checkpoint4PulseCount,
            numberOfMeasurements,
            minPulseCount,
            measurementDurationInSeconds,
            flowSetpointPercent);
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
