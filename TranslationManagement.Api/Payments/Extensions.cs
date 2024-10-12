namespace TranslationManagement.Payments;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddPayments(this IServiceCollection services)
    {
        services.AddSingleton<IPriceCalculator, PriceCalculator>();

        return services;
    }
}