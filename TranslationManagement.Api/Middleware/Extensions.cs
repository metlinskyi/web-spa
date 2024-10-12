namespace TranslationManagement.Middleware;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddTransient<IServiceCollection>(x => services)
                .AddTransient<IStandaloneScope, StandaloneScope>()
                .AddSingleton<IWarmUp, WarmUp>()
                .AddHealthChecks().AddCheck<HealthCheck>(string.Empty);

        return services;
    }
}