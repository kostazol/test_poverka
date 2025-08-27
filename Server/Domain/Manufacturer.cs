using System.Diagnostics.CodeAnalysis;

namespace PoverkaServer.Domain;

public class Manufacturer
{
    public Manufacturer(string editorName, string name)
    {
        Set(editorName, name);
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }

#pragma warning disable CS8618
    private Manufacturer()
    {
    }
#pragma warning restore CS8618

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string EditorName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void Update(string editorName, string name)
    {
        Set(editorName, name);
        UpdatedAt = DateTime.UtcNow;
    }

    [MemberNotNull(nameof(Name), nameof(EditorName))]
    private void Set(string editorName, string name)
    {
        EditorName = editorName;
        Name = name;
    }
}
