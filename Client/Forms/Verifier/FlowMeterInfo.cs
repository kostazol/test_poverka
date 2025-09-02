using PoverkaWinForms.Services;

namespace PoverkaWinForms.Forms.Verifier;

internal record FlowMeterInfo(
    MeterTypeDto? MeterType,
    ManufacturerDto? Manufacturer,
    ModificationDto? Modification,
    RegistrationDto? Registration);
