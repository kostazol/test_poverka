using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using PoverkaServer.Endpoints.Manufacturers.Requests;
using PoverkaServer.Endpoints.Manufacturers.Responses;
using PoverkaServer.Services;
using PoverkaServer.Validation;

namespace PoverkaServer.Endpoints.Manufacturers;

public static class ManufacturerEndpoints
{
    public static IEndpointRouteBuilder MapManufacturerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/manufacturers");
        group.MapGet("", GetManufacturers).WithName("GetManufacturers");
        group.MapGet("{id}", GetManufacturer).WithName("GetManufacturer");
        group.MapPost("", CreateManufacturer).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" }).WithName("CreateManufacturer");
        group.MapPut("{id}", UpdateManufacturer).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" }).WithName("UpdateManufacturer");
        group.MapDelete("{id}", DeleteManufacturer).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" }).WithName("DeleteManufacturer");
        return app;
    }

    private static async Task<Ok<IEnumerable<ManufacturerResponse>>> GetManufacturers(string? search, int? take, ManufacturerService service)
    {
        var items = await service.GetAllAsync(search, take);
        return TypedResults.Ok(items.Select(m => new ManufacturerResponse(m)));
    }

    private static async Task<Results<Ok<ManufacturerResponse>, NotFound>> GetManufacturer(int id, ManufacturerService service)
    {
        var item = await service.GetAsync(id);
        return item is null ? TypedResults.NotFound() : TypedResults.Ok(new ManufacturerResponse(item));
    }

    private static async Task<Ok<int>> CreateManufacturer([Validate] ManufacturerRequest request, ManufacturerService service)
    {
        var manufacturer = await service.CreateAsync(request.EditorName, request.Name);
        return TypedResults.Ok(manufacturer.Id);
    }

    private static async Task<Results<NoContent, NotFound>> UpdateManufacturer(int id, [Validate] ManufacturerRequest request, ManufacturerService service)
    {
        var updated = await service.UpdateAsync(id, request.EditorName, request.Name);
        return updated ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    private static async Task<NoContent> DeleteManufacturer(int id, ManufacturerService service)
    {
        await service.DeleteAsync(id);
        return TypedResults.NoContent();
    }
}
