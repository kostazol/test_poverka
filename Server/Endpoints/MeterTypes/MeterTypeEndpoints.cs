using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Linq;
using PoverkaServer.Endpoints.MeterTypes.Requests;
using PoverkaServer.Endpoints.MeterTypes.Responses;
using PoverkaServer.Services;
using PoverkaServer.Validation;

namespace PoverkaServer.Endpoints.MeterTypes;

public static class MeterTypeEndpoints
{
    public static IEndpointRouteBuilder MapMeterTypeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/metertypes").RequireAuthorization(new AuthorizeAttribute());
        group.MapGet("", GetMeterTypes).WithName("GetMeterTypes");
        group.MapGet("{id}", GetMeterType).WithName("GetMeterType");
        group.MapPost("", CreateMeterType).WithName("CreateMeterType");
        group.MapPut("{id}", UpdateMeterType).WithName("UpdateMeterType");
        group.MapDelete("{id}", DeleteMeterType).WithName("DeleteMeterType");
        return app;
    }

    private static async Task<Ok<IEnumerable<MeterTypeResponse>>> GetMeterTypes(string? search, MeterTypeService service)
    {
        var items = string.IsNullOrWhiteSpace(search)
            ? await service.GetAllAsync()
            : await service.SearchAsync(search);
        return TypedResults.Ok(items.Select(m => new MeterTypeResponse(m)));
    }

    private static async Task<Results<Ok<MeterTypeResponse>, NotFound>> GetMeterType(int id, MeterTypeService service)
    {
        var item = await service.GetAsync(id);
        return item is null ? TypedResults.NotFound() : TypedResults.Ok(new MeterTypeResponse(item));
    }

    private static async Task<Ok<int>> CreateMeterType([Validate] MeterTypeRequest request, MeterTypeService service)
    {
        var meterType = await service.CreateAsync(request.EditorName, request.Type, request.FullName);
        return TypedResults.Ok(meterType.Id);
    }

    private static async Task<Results<NoContent, NotFound>> UpdateMeterType(int id, [Validate] MeterTypeRequest request, MeterTypeService service)
    {
        var updated = await service.UpdateAsync(id, request.EditorName, request.Type, request.FullName);
        return updated ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    private static async Task<NoContent> DeleteMeterType(int id, MeterTypeService service)
    {
        await service.DeleteAsync(id);
        return TypedResults.NoContent();
    }
}

