using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BloggingPlatform.Domain.DI;
public interface IDependencyInjectionInstaller
{
    void Install(IServiceCollection services, ConfigurationManager configuration);
}

public static class DependencyInstaller
{
    public static IServiceCollection InstallServices(
       this IServiceCollection services,
       ConfigurationManager configuration,
       params Assembly[] assemblies)
    {
        IEnumerable<IDependencyInjectionInstaller> serviceInstallers = assemblies
            .SelectMany(_ => _.DefinedTypes)
            .Where(IsAssignableToType<IDependencyInjectionInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IDependencyInjectionInstaller>();

        foreach (IDependencyInjectionInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(services, configuration);
        }

        return services;

        static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
            typeof(T).IsAssignableFrom(typeInfo) &&
            !typeInfo.IsInterface &&
            !typeInfo.IsAbstract;
    }
}
