namespace TranslationManagement.Middleware;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddMiddleware(this IServiceCollection _)
    {
        _.AddHealthChecks().AddCheck<HealthCheck>(string.Empty);

        return _
                .AddTransient<IServiceCollection>(x => _)
                .AddTransient<IStandaloneScope, StandaloneScope>()
                .AddSingleton<IWarmUp, WarmUp>()
                ;
    }
}