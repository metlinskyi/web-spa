namespace TranslationManagement.Data.Management;

public sealed record TranslationRecord
(
    Guid Id,
    Guid CustomerId,
    string OriginalContent,
    string TranslatedContent,
    JobRecrod Job
) : Entity(Id){
    public decimal Price { get; set; }
}