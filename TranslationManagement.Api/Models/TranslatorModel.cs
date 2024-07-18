namespace TranslationManagement.Api.Models;

public class TranslatorModel : ApiModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string HourlyRate { get; set; }
    public string Status { get; set; }
    public string CreditCardNumber { get; set; }
}