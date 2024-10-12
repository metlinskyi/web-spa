namespace TranslationManagement.Middleware;

/// <summary>
/// An interface to provide a standalone scope
/// </summary>
public interface IStandaloneScope 
{
    TResult UseFor<TService, TResult>(Func<TService, TResult> func) where TService: notnull;
}