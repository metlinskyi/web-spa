namespace TranslationManagement.Payments;

using Data;
using Data.Management;
using System;
using System.Linq;

internal class PriceCalculator : IPriceCalculator
{
    private readonly PriceRecord[] _prices;
    public PriceCalculator(IUnitOfWork unitOfWork)
    {
        _prices = unitOfWork.RepositoryFor<PriceRecord>().Get().ToArray();
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