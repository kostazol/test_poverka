using Microsoft.EntityFrameworkCore;
using PoverkaServer.Data;
using PoverkaServer.Domain;
using System.Linq;

namespace PoverkaServer.Services;

public class RegistrationService
{
    private readonly ApplicationDbContext _db;

    public RegistrationService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<List<Registration>> GetAllAsync() => _db.Registrations.ToListAsync();

    public Task<Registration?> GetAsync(int id) => _db.Registrations.FirstOrDefaultAsync(r => r.Id == id);

    public Task<List<int>> GetModificationIdsAsync(int registrationId) =>
        _db.Modifications
            .Where(m => m.RegistrationId == registrationId)
            .Select(m => m.Id)
            .ToListAsync();

    public async Task<Registration> CreateAsync(string editorName, int meterTypeId, string registrationNumber, short verificationInterval, string verificationMethodology, byte relativeErrorQt1_Qmax, byte relativeErrorQt2_Qt1, byte relativeErrorQmin_Qt2, DateOnly registrationDate, DateOnly endDate, bool hasVerificationModeByV, bool hasVerificationModeByG)
    {
        var registration = new Registration(editorName, meterTypeId, registrationNumber, verificationInterval, verificationMethodology, relativeErrorQt1_Qmax, relativeErrorQt2_Qt1, relativeErrorQmin_Qt2, registrationDate, endDate, hasVerificationModeByV, hasVerificationModeByG);
        _db.Registrations.Add(registration);
        await _db.SaveChangesAsync();
        return registration;
    }

    public async Task<bool> UpdateAsync(int id, string editorName, int meterTypeId, string registrationNumber, short verificationInterval, string verificationMethodology, byte relativeErrorQt1_Qmax, byte relativeErrorQt2_Qt1, byte relativeErrorQmin_Qt2, DateOnly registrationDate, DateOnly endDate, bool hasVerificationModeByV, bool hasVerificationModeByG)
    {
        var registration = await _db.Registrations.FindAsync(id);
        if (registration is null)
        {
            return false;
        }
        registration.Update(editorName, meterTypeId, registrationNumber, verificationInterval, verificationMethodology, relativeErrorQt1_Qmax, relativeErrorQt2_Qt1, relativeErrorQmin_Qt2, registrationDate, endDate, hasVerificationModeByV, hasVerificationModeByG);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var registration = await _db.Registrations.FindAsync(id);
        if (registration is not null)
        {
            _db.Registrations.Remove(registration);
            await _db.SaveChangesAsync();
        }
    }
}
