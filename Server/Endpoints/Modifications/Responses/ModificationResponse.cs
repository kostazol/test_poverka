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
    public double PasportImpulseWeight => _modification.PasportImpulseWeight;
    public double VerificationImpulseWeight => _modification.VerificationImpulseWeight;
    public double Qmin => _modification.Qmin;
    public double Qt1 => _modification.Qt1;
    public double Qt2 => _modification.Qt2;
    public double Qmax => _modification.Qmax;
    public double Checkpoint1 => _modification.Checkpoint1;
    public double Checkpoint1RequiredTime => _modification.Checkpoint1RequiredTime;
    public double Checkpoint1TimeMultiplier => _modification.Checkpoint1TimeMultiplier;
    public double Checkpoint1PulseCount => _modification.Checkpoint1PulseCount;
    public double Checkpoint2 => _modification.Checkpoint2;
    public double Checkpoint2RequiredTime => _modification.Checkpoint2RequiredTime;
    public double Checkpoint2TimeMultiplier => _modification.Checkpoint2TimeMultiplier;
    public double Checkpoint2PulseCount => _modification.Checkpoint2PulseCount;
    public double Checkpoint3 => _modification.Checkpoint3;
    public double Checkpoint3RequiredTime => _modification.Checkpoint3RequiredTime;
    public double Checkpoint3TimeMultiplier => _modification.Checkpoint3TimeMultiplier;
    public double Checkpoint3PulseCount => _modification.Checkpoint3PulseCount;
    public double? Checkpoint4 => _modification.Checkpoint4;
    public double? Checkpoint4RequiredTime => _modification.Checkpoint4RequiredTime;
    public double? Checkpoint4TimeMultiplier => _modification.Checkpoint4TimeMultiplier;
    public double? Checkpoint4PulseCount => _modification.Checkpoint4PulseCount;
    public byte NumberOfMeasurements => _modification.NumberOfMeasurements;
    public short MinPulseCount => _modification.MinPulseCount;
    public short MeasurementDurationInSeconds => _modification.MeasurementDurationInSeconds;
    public double FlowSetpointPercent => _modification.FlowSetpointPercent;
    public string EditorName => _modification.EditorName;
    public DateTime CreatedAt => _modification.CreatedAt;
    public DateTime UpdatedAt => _modification.UpdatedAt;
}

