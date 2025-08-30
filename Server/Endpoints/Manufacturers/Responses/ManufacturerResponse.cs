using PoverkaServer.Domain;

namespace PoverkaServer.Endpoints.Manufacturers.Responses;

public class ManufacturerResponse
{
    private readonly Manufacturer _manufacturer;

    public ManufacturerResponse(Manufacturer manufacturer) => _manufacturer = manufacturer;

    public int Id => _manufacturer.Id;
    public string Name => _manufacturer.Name;
    public string EditorName => _manufacturer.EditorName;
    public DateTime CreatedAt => _manufacturer.CreatedAt;
    public DateTime UpdatedAt => _manufacturer.UpdatedAt;
}
