using System.Diagnostics.CodeAnalysis;

namespace PoverkaServer.Domain;

public class Modification
{
    public Modification(
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
        Set(
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
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }

#pragma warning disable CS8618
    private Modification()
    {
    }
#pragma warning restore CS8618

    public int Id { get; private set; }
    public int RegistrationId { get; private set; }
    public string Name { get; private set; }
    public string ClassName { get; private set; }
    public double PasportImpulseWeight { get; private set; }
    public double VerificationImpulseWeight { get; private set; }
    public double Qmin { get; private set; }
    public double Qt1 { get; private set; }
    public double Qt2 { get; private set; }
    public double Qmax { get; private set; }
    public double Checkpoint1 { get; private set; }
    public double Checkpoint1RequiredTime { get; private set; }
    public double Checkpoint1TimeMultiplier { get; private set; }
    public double Checkpoint1PulseCount { get; private set; }
    public double Checkpoint2 { get; private set; }
    public double Checkpoint2RequiredTime { get; private set; }
    public double Checkpoint2TimeMultiplier { get; private set; }
    public double Checkpoint2PulseCount { get; private set; }
    public double Checkpoint3 { get; private set; }
    public double Checkpoint3RequiredTime { get; private set; }
    public double Checkpoint3TimeMultiplier { get; private set; }
    public double Checkpoint3PulseCount { get; private set; }
    public double? Checkpoint4 { get; private set; }
    public double? Checkpoint4RequiredTime { get; private set; }
    public double? Checkpoint4TimeMultiplier { get; private set; }
    public double? Checkpoint4PulseCount { get; private set; }
    public byte NumberOfMeasurements { get; private set; }
    public short MinPulseCount { get; private set; }
    public short MeasurementDurationInSeconds { get; private set; }
    public double FlowSetpointPercent { get; private set; }
    public string EditorName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void Update(
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
        Set(
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
        UpdatedAt = DateTime.UtcNow;
    }

    [MemberNotNull(nameof(Name), nameof(ClassName), nameof(EditorName))]
    private void Set(
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
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(registrationId, nameof(registrationId));
        ArgumentOutOfRangeException.ThrowIfNegative(pasportImpulseWeight, nameof(pasportImpulseWeight));
        ArgumentOutOfRangeException.ThrowIfNegative(verificationImpulseWeight, nameof(verificationImpulseWeight));
        ArgumentOutOfRangeException.ThrowIfNegative(qmin, nameof(qmin));
        ArgumentOutOfRangeException.ThrowIfNegative(qt1, nameof(qt1));
        ArgumentOutOfRangeException.ThrowIfNegative(qt2, nameof(qt2));
        ArgumentOutOfRangeException.ThrowIfNegative(qmax, nameof(qmax));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint1, nameof(checkpoint1));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint1RequiredTime, nameof(checkpoint1RequiredTime));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint1TimeMultiplier, nameof(checkpoint1TimeMultiplier));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint1PulseCount, nameof(checkpoint1PulseCount));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint2, nameof(checkpoint2));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint2RequiredTime, nameof(checkpoint2RequiredTime));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint2TimeMultiplier, nameof(checkpoint2TimeMultiplier));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint2PulseCount, nameof(checkpoint2PulseCount));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint3, nameof(checkpoint3));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint3RequiredTime, nameof(checkpoint3RequiredTime));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint3TimeMultiplier, nameof(checkpoint3TimeMultiplier));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint3PulseCount, nameof(checkpoint3PulseCount));
        if (checkpoint4.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(checkpoint4.Value, nameof(checkpoint4));
        }
        if (checkpoint4RequiredTime.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(checkpoint4RequiredTime.Value, nameof(checkpoint4RequiredTime));
        }
        if (checkpoint4TimeMultiplier.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(checkpoint4TimeMultiplier.Value, nameof(checkpoint4TimeMultiplier));
        }
        if (checkpoint4PulseCount.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(checkpoint4PulseCount.Value, nameof(checkpoint4PulseCount));
        }
        ArgumentOutOfRangeException.ThrowIfNegative(numberOfMeasurements, nameof(numberOfMeasurements));
        ArgumentOutOfRangeException.ThrowIfNegative(minPulseCount, nameof(minPulseCount));
        ArgumentOutOfRangeException.ThrowIfNegative(measurementDurationInSeconds, nameof(measurementDurationInSeconds));
        ArgumentOutOfRangeException.ThrowIfNegative(flowSetpointPercent, nameof(flowSetpointPercent));

        EditorName = editorName;
        RegistrationId = registrationId;
        Name = name;
        ClassName = className;
        PasportImpulseWeight = pasportImpulseWeight;
        VerificationImpulseWeight = verificationImpulseWeight;
        Qmin = qmin;
        Qt1 = qt1;
        Qt2 = qt2;
        Qmax = qmax;
        Checkpoint1 = checkpoint1;
        Checkpoint1RequiredTime = checkpoint1RequiredTime;
        Checkpoint1TimeMultiplier = checkpoint1TimeMultiplier;
        Checkpoint1PulseCount = checkpoint1PulseCount;
        Checkpoint2 = checkpoint2;
        Checkpoint2RequiredTime = checkpoint2RequiredTime;
        Checkpoint2TimeMultiplier = checkpoint2TimeMultiplier;
        Checkpoint2PulseCount = checkpoint2PulseCount;
        Checkpoint3 = checkpoint3;
        Checkpoint3RequiredTime = checkpoint3RequiredTime;
        Checkpoint3TimeMultiplier = checkpoint3TimeMultiplier;
        Checkpoint3PulseCount = checkpoint3PulseCount;
        Checkpoint4 = checkpoint4;
        Checkpoint4RequiredTime = checkpoint4RequiredTime;
        Checkpoint4TimeMultiplier = checkpoint4TimeMultiplier;
        Checkpoint4PulseCount = checkpoint4PulseCount;
        NumberOfMeasurements = numberOfMeasurements;
        MinPulseCount = minPulseCount;
        MeasurementDurationInSeconds = measurementDurationInSeconds;
        FlowSetpointPercent = flowSetpointPercent;
    }
}
