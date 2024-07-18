namespace TranslationManagement.Data.Management;

public sealed record TranslationRecord
(
    Guid Id,
    Guid CustomerId,
    string OriginalContent,
    string TranslatedContent
) : Entity(Id){
    public JobRecrod Job { get; init; }
    public decimal Price { get; init; }
}