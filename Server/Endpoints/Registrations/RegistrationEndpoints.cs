using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using PoverkaServer.Endpoints.Registrations.Requests;
using PoverkaServer.Endpoints.Registrations.Responses;
using PoverkaServer.Services;
using PoverkaServer.Validation;

namespace PoverkaServer.Endpoints.Registrations;

public static class RegistrationEndpoints
{
    public static IEndpointRouteBuilder MapRegistrationEndpoints(this IEndpointRouteBuilder app)
    {
        var groupCommon = app.MapGroup("/api/registrations").RequireAuthorization();
        var groupAdmin = app.MapGroup("/api/registrations").RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });
        groupCommon.MapGet("", GetRegistrations).WithName("GetRegistrations");
        groupCommon.MapGet("{id}", GetRegistration).WithName("GetRegistration");
        groupAdmin.MapPost("", CreateRegistration).WithName("CreateRegistration");
        groupAdmin.MapPut("{id}", UpdateRegistration).WithName("UpdateRegistration");
        groupAdmin.MapDelete("{id}", DeleteRegistration).WithName("DeleteRegistration");
        return app;
    }

    private static async Task<Ok<IEnumerable<RegistrationResponse>>> GetRegistrations(RegistrationService service)
    {
        var items = await service.GetAllAsync();
        var result = new List<RegistrationResponse>();
        foreach (var item in items)
        {
            var modIds = await service.GetModificationIdsAsync(item.Id);
            result.Add(new RegistrationResponse(item, modIds));
        }
        return TypedResults.Ok<IEnumerable<RegistrationResponse>>(result);
    }

    private static async Task<Results<Ok<RegistrationResponse>, NotFound>> GetRegistration(int id, RegistrationService service)
    {
        var item = await service.GetAsync(id);
        if (item is null)
        {
            return TypedResults.NotFound();
        }
        var modIds = await service.GetModificationIdsAsync(item.Id);
        return TypedResults.Ok(new RegistrationResponse(item, modIds));
    }

    private static async Task<Ok<int>> CreateRegistration([Validate] RegistrationRequest request, RegistrationService service)
    {
        var registration = await service.CreateAsync(request.EditorName, request.MeterTypeId, request.RegistrationNumber, request.VerificationInterval, request.VerificationMethodology, request.RelativeErrorQt1_Qmax, request.RelativeErrorQt2_Qt1, request.RelativeErrorQmin_Qt2, request.RegistrationDate, request.EndDate, request.HasVerificationModeByV, request.HasVerificationModeByG);
        return TypedResults.Ok(registration.Id);
    }

    private static async Task<Results<NoContent, NotFound>> UpdateRegistration(int id, [Validate] RegistrationRequest request, RegistrationService service)
    {
        var updated = await service.UpdateAsync(id, request.EditorName, request.MeterTypeId, request.RegistrationNumber, request.VerificationInterval, request.VerificationMethodology, request.RelativeErrorQt1_Qmax, request.RelativeErrorQt2_Qt1, request.RelativeErrorQmin_Qt2, request.RegistrationDate, request.EndDate, request.HasVerificationModeByV, request.HasVerificationModeByG);
        return updated ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    private static async Task<NoContent> DeleteRegistration(int id, RegistrationService service)
    {
        await service.DeleteAsync(id);
        return TypedResults.NoContent();
    }
}

