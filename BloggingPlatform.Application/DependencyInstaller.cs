using BloggingPlatform.Domain;
using BloggingPlatform.Domain.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloggingPlatform.Application;
public class DependencyInstaller : IDependencyInjectionInstaller
{
    public void Install(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddGlobalExceptionHandler();
        services.AddMessaging(typeof(DependencyInstaller).Assembly);
    }
}
