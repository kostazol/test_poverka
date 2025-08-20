using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PoverkaServer.Models;
using PoverkaServer.Validation;
using System.Collections.Generic;
using System.Linq;

namespace PoverkaServer.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
    {
        var users = group.MapGroup("/users")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

        users.MapGet("", GetUsers).WithName("GetUsers");
        users.MapPost("", CreateUser).WithName("CreateUser");

        return group;
    }

    private static IEnumerable<string> GetUsers(UserManager<IdentityUser> userManager)
        => userManager.Users
            .Where(u => u.UserName != null)
            .Select(u => u.UserName!);

    private static async Task<IResult> CreateUser([Validate] UserCreateRequest request, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = request.UserName };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors);

        await userManager.AddToRoleAsync(user, request.Role);
        return Results.Ok();
    }
}

