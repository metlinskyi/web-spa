namespace TranslationManagement.Data;

/// <summary>
/// The base abstract of a database entity
/// </summary>
/// <param name="Id">The primary key of a table record.</param>
public abstract record Entity(
    Guid Id
) {
    public override int GetHashCode() => Id.GetHashCode();
    public override string ToString() =>  Id.ToString();
};