using System.Diagnostics.CodeAnalysis;

namespace PoverkaServer.Domain;

public class Registration
{
    public Registration(string editorName, int meterTypeId, string registrationNumber, short verificationInterval, string verificationMethodology, byte relativeErrorQt1_Qmax, byte relativeErrorQt2_Qt1, byte relativeErrorQmin_Qt2, DateOnly registrationDate, DateOnly endDate, bool hasVerificationModeByV, bool hasVerificationModeByG)
    {
        Set(editorName, meterTypeId, registrationNumber, verificationInterval, verificationMethodology, relativeErrorQt1_Qmax, relativeErrorQt2_Qt1, relativeErrorQmin_Qt2, registrationDate, endDate, hasVerificationModeByV, hasVerificationModeByG);
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }

#pragma warning disable CS8618
    private Registration()
    {
    }
#pragma warning restore CS8618

    public int Id { get; private set; }
    public int MeterTypeId { get; private set; }
    public string RegistrationNumber { get; private set; }
    public short VerificationInterval { get; private set; }
    public string VerificationMethodology { get; private set; }
    public byte RelativeErrorQt1_Qmax { get; private set; }
    public byte RelativeErrorQt2_Qt1 { get; private set; }
    public byte RelativeErrorQmin_Qt2 { get; private set; }
    public DateOnly RegistrationDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public bool HasVerificationModeByV { get; private set; }
    public bool HasVerificationModeByG { get; private set; }
    public string EditorName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void Update(string editorName, int meterTypeId, string registrationNumber, short verificationInterval, string verificationMethodology, byte relativeErrorQt1_Qmax, byte relativeErrorQt2_Qt1, byte relativeErrorQmin_Qt2, DateOnly registrationDate, DateOnly endDate, bool hasVerificationModeByV, bool hasVerificationModeByG)
    {
        Set(editorName, meterTypeId, registrationNumber, verificationInterval, verificationMethodology, relativeErrorQt1_Qmax, relativeErrorQt2_Qt1, relativeErrorQmin_Qt2, registrationDate, endDate, hasVerificationModeByV, hasVerificationModeByG);
        UpdatedAt = DateTime.UtcNow;
    }

    [MemberNotNull(nameof(RegistrationNumber), nameof(VerificationMethodology), nameof(EditorName))]
    private void Set(string editorName, int meterTypeId, string registrationNumber, short verificationInterval, string verificationMethodology, byte relativeErrorQt1_Qmax, byte relativeErrorQt2_Qt1, byte relativeErrorQmin_Qt2, DateOnly registrationDate, DateOnly endDate, bool hasVerificationModeByV, bool hasVerificationModeByG)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(meterTypeId, nameof(meterTypeId));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(verificationInterval, nameof(verificationInterval));
        ArgumentOutOfRangeException.ThrowIfNegative(relativeErrorQt1_Qmax, nameof(relativeErrorQt1_Qmax));
        ArgumentOutOfRangeException.ThrowIfNegative(relativeErrorQt2_Qt1, nameof(relativeErrorQt2_Qt1));
        ArgumentOutOfRangeException.ThrowIfNegative(relativeErrorQmin_Qt2, nameof(relativeErrorQmin_Qt2));

        EditorName = editorName;
        MeterTypeId = meterTypeId;
        RegistrationNumber = registrationNumber;
        VerificationInterval = verificationInterval;
        VerificationMethodology = verificationMethodology;
        RelativeErrorQt1_Qmax = relativeErrorQt1_Qmax;
        RelativeErrorQt2_Qt1 = relativeErrorQt2_Qt1;
        RelativeErrorQmin_Qt2 = relativeErrorQmin_Qt2;
        RegistrationDate = registrationDate;
        EndDate = endDate;
        HasVerificationModeByV = hasVerificationModeByV;
        HasVerificationModeByG = hasVerificationModeByG;
    }
}
