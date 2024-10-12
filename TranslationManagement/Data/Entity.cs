namespace TranslationManagement.Data;

/// <summary>
/// The base abstract of a database entity
/// </summary>
/// <param name="Id"></param>
public abstract record Entity(
    Guid Id
);
