using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PoverkaServer.Data;
using PoverkaServer.Models;
using PoverkaServer.Settings;

namespace PoverkaServer;

public static class MigrationExtensions
{
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var configContext = services.GetRequiredService<ConfigurationDbContext>();
        await configContext.Database.MigrateAsync();

        if (!configContext.Clients.Any())
        {
            foreach (var client in IdentityConfig.Clients)
                configContext.Clients.Add(client.ToEntity());
            await configContext.SaveChangesAsync();
        }
        if (!configContext.ApiScopes.Any())
        {
            foreach (var scopeDef in IdentityConfig.ApiScopes)
                configContext.ApiScopes.Add(scopeDef.ToEntity());
            await configContext.SaveChangesAsync();
        }
        if (!configContext.ApiResources.Any())
        {
            foreach (var resource in IdentityConfig.ApiResources)
                configContext.ApiResources.Add(resource.ToEntity());
            await configContext.SaveChangesAsync();
        }

        var grantContext = services.GetRequiredService<PersistedGrantDbContext>();
        await grantContext.Database.MigrateAsync();

        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();

        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var role in Roles.All)
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        if (await userManager.FindByNameAsync("admin") is null)
        {
            var admin = new ApplicationUser { UserName = "admin" };
            admin.PasswordHash = userManager.PasswordHasher.HashPassword(admin, "admin");
            var result = await userManager.CreateAsync(admin);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, "Admin");
        }

        if (await userManager.FindByNameAsync("verifier") is null)
        {
            var verifier = new ApplicationUser { UserName = "verifier" };
            verifier.PasswordHash = userManager.PasswordHasher.HashPassword(verifier, "verifier");
            var result = await userManager.CreateAsync(verifier);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(verifier, "Verifier");
        }
    }
}
