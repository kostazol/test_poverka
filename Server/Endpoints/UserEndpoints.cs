using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PoverkaServer.Models;
using PoverkaServer.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PoverkaServer.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPut("/api/users/password", ChangePassword)
            .RequireAuthorization()
            .WithName("ChangePassword");

        var users = app.MapGroup("/api/users")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

        users.MapGet("", GetUsers).WithName("GetUsers");
        users.MapPost("", CreateUser).WithName("CreateUser");
        users.MapPut("{id}", UpdateUser).WithName("UpdateUser");
        users.MapPut("{id}/password", SetPassword).WithName("SetPassword");

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
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            LastName = request.LastName,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName
        };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors.First().Description);

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
            return Results.BadRequest(result.Errors.First().Description);

        return Results.Ok();
    }

    private static async Task<IResult> SetPassword(string id, [Validate] SetPasswordRequest request, UserManager<ApplicationUser> userManager)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
            return Results.NotFound();

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var result = await userManager.ResetPasswordAsync(user, token, request.Password);
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors.First().Description);

        return Results.Ok();
    }

    private static async Task<IResult> ChangePassword([Validate] ChangePasswordRequest request, UserManager<ApplicationUser> userManager, ClaimsPrincipal principal)
    {
        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null)
            return Results.NotFound();

        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            return Results.NotFound();

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
            return Results.BadRequest(result.Errors.First().Description);

        return Results.Ok();
    }
}

