namespace TranslationManagement;

using Microsoft.Extensions.DependencyInjection;
using Payments;

public static class Extensions
{
    public static IServiceCollection AddPayments(this IServiceCollection services)
    {
        return services.AddScoped<IPriceCalculator, PriceCalculator>();
    }
}