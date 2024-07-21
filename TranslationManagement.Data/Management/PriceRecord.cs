namespace TranslationManagement.Data.Management;

using Data;
using Payments;

public sealed record PriceRecord(
    Guid Id,
    PriceType Type,
    decimal Amount
) : Entity(Id);
