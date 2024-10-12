using TranslationManagement.Middleware;

using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class WarmUp : IWarmUp
{
    public WarmUp(
        ILogger<WarmUp> logger,
        IServiceProvider serviceProvider)
    {
        logger.LogInformation("Warm Up!");

        var serviceCollection = serviceProvider.GetRequiredService<IServiceCollection>();
        foreach(var serviceType in serviceCollection
            .Where(descriptor => 
                    descriptor.Lifetime == ServiceLifetime.Singleton && 
                    descriptor.ImplementationType != typeof(WarmUp) &&     
                    typeof(IWarmUp).IsAssignableFrom(descriptor.ImplementationType))
            .Select(descriptor => descriptor.ServiceType))
        {
            serviceProvider.GetRequiredService(serviceType);
            logger.LogInformation($"{serviceType} was warmed up!"); 
        }
    }
}