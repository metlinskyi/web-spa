namespace TranslationManagement.Data;

public interface IRepository
{
}

public interface IRepository<TEntity> : IRepository where TEntity : Entity
{
    IEnumerable<TEntity> Get(params string[] includeProperties);

    TEntity? GetByID(Guid id);    

    Task<TEntity?> GetByIDAsync(Guid id);

    void Insert(TEntity entity);
        
    Task InsertAsync(TEntity entity);

    void Delete(Guid id);

    void Delete(TEntity entityToDelete);

    void Update(TEntity entityToUpdate);
}