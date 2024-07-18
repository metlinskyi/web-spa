namespace TranslationManagement.Data.Management;

public sealed record CustomerRecord
(
    Guid Id
) : Entity(Id){
    public string Name { get; init; }
}