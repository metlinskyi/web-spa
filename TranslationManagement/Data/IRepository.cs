using System.Linq.Expressions;

namespace TranslationManagement.Data;

/// <summary>
/// The placeholder of repositories
/// </summary>
public interface IRepository{}

public interface IRepository<TEntity> : IRepository where TEntity : Entity
{
    IQueryable<TEntity> Get(params string[] includeProperties);
    Task<TEntity?> GetBy(Expression<Func<TEntity, bool>> predicate);
    TEntity Insert(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
}