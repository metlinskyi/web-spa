namespace TranslationManagement.Data;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : Entity;

    int Save();

    Task<int> SaveAsync();
}