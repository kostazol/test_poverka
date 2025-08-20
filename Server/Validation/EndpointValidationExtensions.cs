using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PoverkaServer.Validation;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class ValidateAttribute : Attribute;

public static class EndpointValidationExtensions
{
    public static RouteHandlerBuilder WithParameterValidation(this RouteHandlerBuilder builder)
    {
        builder.AddEndpointFilter(new ValidationFilter());
        return builder;
    }

    public static IServiceCollection AddParameterValidation(this IServiceCollection services)
    {
        services.AddSingleton<IEndpointFilter, ValidationFilter>();
        return services;
    }

    private sealed class ValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var method = context.HttpContext.GetEndpoint()?.Metadata.GetMetadata<MethodInfo>();
            if (method is not null)
            {
                var parameters = method.GetParameters();
                for (var i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].GetCustomAttribute<ValidateAttribute>() is null)
                        continue;

                    var argument = context.Arguments[i];
                    var validationContext = new ValidationContext(argument!);
                    var validationResults = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(argument!, validationContext, validationResults, true))
                        return Results.BadRequest(validationResults);
                }
            }

            return await next(context);
        }
    }
}
