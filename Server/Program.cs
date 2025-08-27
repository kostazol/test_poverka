using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PoverkaServer;
using PoverkaServer.Data;
using PoverkaServer.Endpoints;
using PoverkaServer.Endpoints.MeterTypes;
using PoverkaServer.Endpoints.Registrations;
using PoverkaServer.Endpoints.Modifications;
using PoverkaServer.Endpoints.Manufacturers;
using PoverkaServer.Validation;
using PoverkaServer.Models;
using PoverkaServer.Services;
using PoverkaServer.Settings;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poverka API", Version = "v1" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Введите JWT токен"
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});

builder.Services.AddScoped<MeterTypeService>();
builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<ModificationService>();
builder.Services.AddScoped<ManufacturerService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

await app.ApplyMigrationsAsync();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapUserEndpoints();
app.MapMeterTypeEndpoints();
app.MapRegistrationEndpoints();
app.MapModificationEndpoints();
app.MapManufacturerEndpoints();

await app.RunAsync();
