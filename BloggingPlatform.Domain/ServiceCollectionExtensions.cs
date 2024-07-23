using BloggingPlatform.Domain.Middlewares;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BloggingPlatform.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<ExceptionHandlerMiddleware>();
        services.AddProblemDetails();

        return services;
    }

    public static IServiceCollection AddMessaging(this IServiceCollection services, Assembly fromAssembly)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(fromAssembly);

            configuration.AddOpenBehavior(typeof(LoggingMiddleware<,>));
            configuration.AddOpenBehavior(typeof(ValidationMiddleware<,>));
        });

        services.AddValidatorsFromAssembly(fromAssembly);

        return services;
    }
}