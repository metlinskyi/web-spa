namespace TranslationManagement.Data.Management;

public sealed record TranslatorRecord
(
    Guid Id,
    string Name,
    string HourlyRate,
    string CreditCardNumber
) : Entity(Id) {
    public TranslatorStatus Status { get; init; }
}
