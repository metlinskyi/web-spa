namespace TranslationManagement.Payments;

public interface IPriceCalculator 
{
    decimal Translation(PriceType type, string content);
}
