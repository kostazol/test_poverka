using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Linq;
using PoverkaServer.Endpoints.Modifications.Requests;
using PoverkaServer.Endpoints.Modifications.Responses;
using PoverkaServer.Domain;
using PoverkaServer.Services;
using PoverkaServer.Validation;

namespace PoverkaServer.Endpoints.Modifications;

public static class ModificationEndpoints
{
    public static IEndpointRouteBuilder MapModificationEndpoints(this IEndpointRouteBuilder app)
    {
        var groupCommon = app.MapGroup("/api/modifications").RequireAuthorization();
        var groupAdmin = app.MapGroup("/api/modifications").RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });
        groupCommon.MapGet("", GetModifications).WithName("GetModifications");
        groupCommon.MapGet("{id}", GetModification).WithName("GetModification");
        groupAdmin.MapPost("", CreateModification).WithName("CreateModification");
        groupAdmin.MapPut("{id}", UpdateModification).WithName("UpdateModification");
        groupAdmin.MapDelete("{id}", DeleteModification).WithName("DeleteModification");
        return app;
    }

    private static async Task<Ok<IEnumerable<ModificationResponse>>> GetModifications(
        int? meterTypeId,
        string? manufacturerName,
        DateOnly? manufactureDate,
        ModificationService service)
    {
        IEnumerable<ModificationWithRegistrationNumber> items;
        if (meterTypeId.HasValue && !string.IsNullOrWhiteSpace(manufacturerName) && manufactureDate.HasValue)
        {
            items = await service.GetFilteredAsync(
                meterTypeId.Value,
                manufacturerName,
                manufactureDate.Value
            );
        }
        else
        {
            items = await service.GetAllAsync();
        }

        return TypedResults.Ok(items.Select(m => new ModificationResponse(m.Modification, m.RegistrationNumber)));
    }

    private static async Task<Results<Ok<ModificationResponse>, NotFound>> GetModification(int id, ModificationService service)
    {
        var item = await service.GetAsync(id);
        if (item is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(new ModificationResponse(item.Modification, item.RegistrationNumber));
    }

    private static async Task<Ok<int>> CreateModification([Validate] ModificationRequest request, ModificationService service)
    {
        var modification = await service.CreateAsync(
            request.EditorName,
            request.RegistrationId,
            request.Name,
            request.ClassName,
            request.ImpulseWeight,
            request.Qmin,
            request.Qt1,
            request.Qt2,
            request.Qmax,
            request.Checkpoint1,
            request.Checkpoint2,
            request.Checkpoint3,
            request.Checkpoint4,
            request.NumberOfMeasurements,
            request.MinPulseCount,
            request.MeasurementDurationInSeconds,
            request.RelativeErrorWithStandartValue);
        return TypedResults.Ok(modification.Id);
    }

    private static async Task<Results<NoContent, NotFound>> UpdateModification(int id, [Validate] ModificationRequest request, ModificationService service)
    {
        var updated = await service.UpdateAsync(
            id,
            request.EditorName,
            request.RegistrationId,
            request.Name,
            request.ClassName,
            request.ImpulseWeight,
            request.Qmin,
            request.Qt1,
            request.Qt2,
            request.Qmax,
            request.Checkpoint1,
            request.Checkpoint2,
            request.Checkpoint3,
            request.Checkpoint4,
            request.NumberOfMeasurements,
            request.MinPulseCount,
            request.MeasurementDurationInSeconds,
            request.RelativeErrorWithStandartValue);
        return updated ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    private static async Task<NoContent> DeleteModification(int id, ModificationService service)
    {
        await service.DeleteAsync(id);
        return TypedResults.NoContent();
    }
}

