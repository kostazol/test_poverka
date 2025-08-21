using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PoverkaServer.Models;
using PoverkaServer.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoverkaServer.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var users = app.MapGroup("/api/users")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

        users.MapGet("", GetUsers).WithName("GetUsers");
        users.MapPost("", CreateUser).WithName("CreateUser");
        users.MapPut("{id}", UpdateUser).WithName("UpdateUser");
        users.MapPut("{id}/password", ChangePassword).WithName("ChangePassword");

        return app;
    }

    private static async Task<IResult> GetUsers(UserManager<ApplicationUser> userManager)
    {
        var users = await userManager.Users.ToListAsync();
        var result = new List<UserResponse>();
        foreach (var user in users)
        {
            var roles = await userManager.GetRolesAsync(user);
            result.Add(new UserResponse(
                user.Id,
                user.UserName ?? string.Empty,
                roles.FirstOrDefault() ?? string.Empty,
                user.LastName,
                user.FirstName,
                user.MiddleName));
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> CreateUser([Validate] UserCreateRequest request, UserManager<ApplicationUser> userManager)
    {
        var user = new ApplicationUser { UserName = request.UserName };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors);

        await userManager.AddToRoleAsync(user, request.Role);
        return Results.Ok();
    }

    private static async Task<IResult> UpdateUser(string id, [Validate] UserUpdateRequest request, UserManager<ApplicationUser> userManager)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
            return Results.NotFound();

        user.LastName = request.LastName;
        user.FirstName = request.FirstName;
        user.MiddleName = request.MiddleName;

        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors);

        return Results.Ok();
    }

    private static async Task<IResult> ChangePassword(string id, [Validate] ChangePasswordRequest request, UserManager<ApplicationUser> userManager)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
            return Results.NotFound();

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var result = await userManager.ResetPasswordAsync(user, token, request.Password);
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors);

        return Results.Ok();
    }
}

