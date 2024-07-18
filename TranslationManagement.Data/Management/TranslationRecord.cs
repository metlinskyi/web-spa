namespace TranslationManagement.Data.Management;

public sealed record TranslationRecord
(
    Guid Id,
    string OriginalContent,
    string TranslatedContent
) : Entity(Id){
    public CustomerRecord Customer { get; init; }
    public JobRecrod Job { get; init; }
    public decimal Price { get; init; }
}