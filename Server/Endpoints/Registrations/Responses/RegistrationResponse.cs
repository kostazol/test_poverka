using PoverkaServer.Domain;
using System.Collections.Generic;

namespace PoverkaServer.Endpoints.Registrations.Responses;

public class RegistrationResponse
{
    private readonly Registration _registration;
    private readonly IReadOnlyList<int> _modificationIds;

    public RegistrationResponse(Registration registration, IReadOnlyList<int> modificationIds)
    {
        _registration = registration;
        _modificationIds = modificationIds;
    }

    public int Id => _registration.Id;
    public int MeterTypeId => _registration.MeterTypeId;
    public IReadOnlyList<int> ModificationIds => _modificationIds;
    public string RegistrationNumber => _registration.RegistrationNumber;
    public short VerificationInterval => _registration.VerificationInterval;
    public string VerificationMethodology => _registration.VerificationMethodology;
    public byte RelativeErrorQt1_Qmax => _registration.RelativeErrorQt1_Qmax;
    public byte RelativeErrorQt2_Qt1 => _registration.RelativeErrorQt2_Qt1;
    public byte RelativeErrorQmin_Qt2 => _registration.RelativeErrorQmin_Qt2;
    public DateOnly RegistrationDate => _registration.RegistrationDate;
    public DateOnly EndDate => _registration.EndDate;
    public bool HasVerificationModeByV => _registration.HasVerificationModeByV;
    public bool HasVerificationModeByG => _registration.HasVerificationModeByG;
    public string EditorName => _registration.EditorName;
    public DateTime CreatedAt => _registration.CreatedAt;
    public DateTime UpdatedAt => _registration.UpdatedAt;
}

