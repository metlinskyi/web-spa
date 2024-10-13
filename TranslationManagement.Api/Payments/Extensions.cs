namespace TranslationManagement.Payments;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    public static IServiceCollection AddPayments(this IServiceCollection _)
    {
        return _
                .AddSingleton<IPriceCalculator, PriceCalculator>()
                ;
    }
}