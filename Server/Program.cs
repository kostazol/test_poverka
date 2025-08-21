using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PoverkaServer;
using PoverkaServer.Data;
using PoverkaServer.Endpoints;
using PoverkaServer.Validation;
using PoverkaServer.Models;

var builder = WebApplication.CreateBuilder(args);

var applicationConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(applicationConnectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServerSettings(builder.Configuration);

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseNpgsql(identityConnectionString,
                sql => sql.MigrationsAssembly(typeof(Program).Assembly.GetName().Name));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseNpgsql(identityConnectionString,
                sql => sql.MigrationsAssembly(typeof(Program).Assembly.GetName().Name));
    })
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer();

builder.Services.AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
    .Configure<IdentityServerSettings>((options, settings) =>
    {
        options.Authority = settings.Authority;
        options.Audience = "api";
        options.RequireHttpsMetadata = settings.RequireHttpsMetadata;
    });

builder.Services.AddAuthorization();
builder.Services.AddParameterValidation();

var app = builder.Build();

await app.ApplyMigrationsAsync();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapUserEndpoints();

await app.RunAsync();
