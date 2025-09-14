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
        double checkpoint2,
        double checkpoint3,
        double? checkpoint4,
        byte numberOfMeasurements,
        short minPulseCount,
        short measurementDurationInSeconds,
        byte relativeErrorWithStandartValue)
    {
        Set(editorName, registrationId, name, className, pasportImpulseWeight, verificationImpulseWeight, qmin, qt1, qt2, qmax,
            checkpoint1, checkpoint2, checkpoint3, checkpoint4, numberOfMeasurements,
            minPulseCount, measurementDurationInSeconds, relativeErrorWithStandartValue);
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
    public double Checkpoint2 { get; private set; }
    public double Checkpoint3 { get; private set; }
    public double? Checkpoint4 { get; private set; }
    public byte NumberOfMeasurements { get; private set; }
    public short MinPulseCount { get; private set; }
    public short MeasurementDurationInSeconds { get; private set; }
    public byte RelativeErrorWithStandartValue { get; private set; }
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
        double checkpoint2,
        double checkpoint3,
        double? checkpoint4,
        byte numberOfMeasurements,
        short minPulseCount,
        short measurementDurationInSeconds,
        byte relativeErrorWithStandartValue)
    {
        Set(editorName, registrationId, name, className, pasportImpulseWeight, verificationImpulseWeight, qmin, qt1, qt2, qmax,
            checkpoint1, checkpoint2, checkpoint3, checkpoint4, numberOfMeasurements,
            minPulseCount, measurementDurationInSeconds, relativeErrorWithStandartValue);
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
        double checkpoint2,
        double checkpoint3,
        double? checkpoint4,
        byte numberOfMeasurements,
        short minPulseCount,
        short measurementDurationInSeconds,
        byte relativeErrorWithStandartValue)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(registrationId, nameof(registrationId));
        ArgumentOutOfRangeException.ThrowIfNegative(pasportImpulseWeight, nameof(pasportImpulseWeight));
        ArgumentOutOfRangeException.ThrowIfNegative(verificationImpulseWeight, nameof(verificationImpulseWeight));
        ArgumentOutOfRangeException.ThrowIfNegative(qmin, nameof(qmin));
        ArgumentOutOfRangeException.ThrowIfNegative(qt1, nameof(qt1));
        ArgumentOutOfRangeException.ThrowIfNegative(qt2, nameof(qt2));
        ArgumentOutOfRangeException.ThrowIfNegative(qmax, nameof(qmax));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint1, nameof(checkpoint1));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint2, nameof(checkpoint2));
        ArgumentOutOfRangeException.ThrowIfNegative(checkpoint3, nameof(checkpoint3));
        if (checkpoint4.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(checkpoint4.Value, nameof(checkpoint4));
        }
        ArgumentOutOfRangeException.ThrowIfNegative(numberOfMeasurements, nameof(numberOfMeasurements));
        ArgumentOutOfRangeException.ThrowIfNegative(minPulseCount, nameof(minPulseCount));
        ArgumentOutOfRangeException.ThrowIfNegative(measurementDurationInSeconds, nameof(measurementDurationInSeconds));
        ArgumentOutOfRangeException.ThrowIfNegative(relativeErrorWithStandartValue, nameof(relativeErrorWithStandartValue));

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
        Checkpoint2 = checkpoint2;
        Checkpoint3 = checkpoint3;
        Checkpoint4 = checkpoint4;
        NumberOfMeasurements = numberOfMeasurements;
        MinPulseCount = minPulseCount;
        MeasurementDurationInSeconds = measurementDurationInSeconds;
        RelativeErrorWithStandartValue = relativeErrorWithStandartValue;
    }
}
