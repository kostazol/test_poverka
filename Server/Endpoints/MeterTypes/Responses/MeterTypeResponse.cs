using PoverkaServer.Domain;

namespace PoverkaServer.Endpoints.MeterTypes.Responses;

public class MeterTypeResponse
{
    private readonly MeterType _meterType;

    public MeterTypeResponse(MeterType meterType) => _meterType = meterType;

    public int Id => _meterType.Id;
    public int ManufacturerId => _meterType.ManufacturerId;
    public string Type => _meterType.Type;
    public string FullName => _meterType.FullName;
    public string EditorName => _meterType.EditorName;
    public DateTime CreatedAt => _meterType.CreatedAt;
    public DateTime UpdatedAt => _meterType.UpdatedAt;
}

