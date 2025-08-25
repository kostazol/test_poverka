using Microsoft.EntityFrameworkCore;
using PoverkaServer.Data;
using PoverkaServer.Domain;

namespace PoverkaServer.Services;

public class MeterTypeService
{
    private readonly ApplicationDbContext _db;

    public MeterTypeService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<List<MeterType>> GetAllAsync(string? search = null, int? take = null)
    {
        IQueryable<MeterType> query = _db.MeterTypes;

        if (!string.IsNullOrWhiteSpace(search))
        {
            var pattern = $"%{search}%";
            query = query.Where(m => EF.Functions.ILike(m.Type, pattern));
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return query.OrderBy(m => m.Type).ToListAsync();
    }

    public Task<MeterType?> GetAsync(int id) => _db.MeterTypes.FindAsync(id).AsTask();

    public async Task<MeterType> CreateAsync(string editorName, string type, string fullName)
    {
        var meterType = new MeterType(editorName, type, fullName);
        _db.MeterTypes.Add(meterType);
        await _db.SaveChangesAsync();
        return meterType;
    }

    public async Task<bool> UpdateAsync(int id, string editorName, string type, string fullName)
    {
        var meterType = await _db.MeterTypes.FindAsync(id);
        if (meterType is null)
        {
            return false;
        }
        meterType.Update(editorName, type, fullName);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var meterType = await _db.MeterTypes.FindAsync(id);
        if (meterType is not null)
        {
            _db.MeterTypes.Remove(meterType);
            await _db.SaveChangesAsync();
        }
    }
}
