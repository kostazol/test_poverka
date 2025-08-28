using Microsoft.EntityFrameworkCore;
using PoverkaServer.Data;
using PoverkaServer.Domain;

namespace PoverkaServer.Services;

public class ManufacturerService
{
    private readonly ApplicationDbContext _db;

    public ManufacturerService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<List<Manufacturer>> GetAllAsync(string? search = null, int? take = null)
    {
        IQueryable<Manufacturer> query = _db.Manufacturers;
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(m => EF.Functions.ILike(m.Name, $"%{search}%"));
        }
        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }
        return query.OrderBy(m => m.Name).ToListAsync();
    }

    public Task<Manufacturer?> GetAsync(int id) => _db.Manufacturers.FindAsync(id).AsTask();

    public async Task<Manufacturer> CreateAsync(string editorName, string name)
    {
        var manufacturer = new Manufacturer(editorName, name);
        _db.Manufacturers.Add(manufacturer);
        await _db.SaveChangesAsync();
        return manufacturer;
    }

    public async Task<bool> UpdateAsync(int id, string editorName, string name)
    {
        var manufacturer = await _db.Manufacturers.FindAsync(id);
        if (manufacturer is null)
        {
            return false;
        }
        manufacturer.Update(editorName, name);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var manufacturer = await _db.Manufacturers.FindAsync(id);
        if (manufacturer is not null)
        {
            _db.Manufacturers.Remove(manufacturer);
            await _db.SaveChangesAsync();
        }
    }
}
