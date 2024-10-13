
using TranslationManagement.Middleware;

using System;
using Microsoft.Extensions.DependencyInjection;

internal class StandaloneScope(
    IServiceProvider serviceProvider
    ) : IStandaloneScope
{
    public TResult UseFor<TService, TResult>(Func<TService, TResult> func) where TService : notnull
    {
        TResult result = default;

        using(var scope = serviceProvider.CreateScope())
        {
            var service = scope.ServiceProvider.GetRequiredService<TService>();
            result = func(service);
        }

        return result;
    }
}