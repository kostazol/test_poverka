using System.Diagnostics.CodeAnalysis;

namespace PoverkaServer.Domain;

public class MeterType
{
    public MeterType(string editorName, string type, string fullName)
    {
        Set(editorName, type, fullName);
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }

#pragma warning disable CS8618
    private MeterType()
    {
    }
#pragma warning restore CS8618

    public int Id { get; private set; }
    public string Type { get; private set; }
    public string FullName { get; private set; }
    public string EditorName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void Update(string editorName, string type, string fullName)
    {
        Set(editorName, type, fullName);
        UpdatedAt = DateTime.UtcNow;
    }

    [MemberNotNull(nameof(EditorName), nameof(Type), nameof(FullName))]
    private void Set(string editorName, string type, string fullName)
    {
        EditorName = editorName;
        Type = type;
        FullName = fullName;
    }
}
