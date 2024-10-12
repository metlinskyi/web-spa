namespace TranslationManagement.Payments;

using Data;
using Data.Management;
using Microsoft.Extensions.Logging;
using Middleware;
using System;
using System.Linq;

internal class PriceCalculator : IPriceCalculator, IWarmUp
{
    private readonly PriceRecord[] _prices;

    public PriceCalculator(
        ILogger<PriceCalculator> logger, 
        IStandaloneScope scope)
    {       
        logger.LogInformation("Let's calc!");

        _prices = scope.UseFor<IRepository<PriceRecord>, PriceRecord[]>(x => x.Get().ToArray());
    }

    public decimal Translation(PriceType type, string content)
    {
        var price = _prices.Single(price => price.Type == type);

        return type switch
        {
            PriceType.PerCharacter => content.Length * price.Amount,
            _ => throw new NotSupportedException(),
        };
    }
}