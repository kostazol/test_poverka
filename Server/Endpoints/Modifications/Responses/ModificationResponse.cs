using PoverkaServer.Domain;

namespace PoverkaServer.Endpoints.Modifications.Responses;

public class ModificationResponse
{
    private readonly Modification _modification;
    private readonly string _registrationNumber;

    public ModificationResponse(Modification modification, string registrationNumber)
    {
        _modification = modification;
        _registrationNumber = registrationNumber;
    }

    public int Id => _modification.Id;
    public int RegistrationId => _modification.RegistrationId;
    public string RegistrationNumber => _registrationNumber;
    public string Name => _modification.Name;
    public string ClassName => _modification.ClassName;
    public double ImpulseWeight => _modification.ImpulseWeight;
    public double Qmin => _modification.Qmin;
    public double Qt1 => _modification.Qt1;
    public double Qt2 => _modification.Qt2;
    public double Qmax => _modification.Qmax;
    public double Checkpoint1 => _modification.Checkpoint1;
    public double Checkpoint2 => _modification.Checkpoint2;
    public double Checkpoint3 => _modification.Checkpoint3;
    public double? Checkpoint4 => _modification.Checkpoint4;
    public byte NumberOfMeasurements => _modification.NumberOfMeasurements;
    public short MinPulseCount => _modification.MinPulseCount;
    public short MeasurementDurationInSeconds => _modification.MeasurementDurationInSeconds;
    public byte RelativeErrorWithStandartValue => _modification.RelativeErrorWithStandartValue;
    public string EditorName => _modification.EditorName;
    public DateTime CreatedAt => _modification.CreatedAt;
    public DateTime UpdatedAt => _modification.UpdatedAt;
}

