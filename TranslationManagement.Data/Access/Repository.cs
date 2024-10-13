namespace TranslationManagement.Data.Access;

using Microsoft.EntityFrameworkCore;
using Data.Management;
using System.Linq.Expressions;

public class Repository<TEntity>(
    AppDbContext context
    ) : IRepository<TEntity> where TEntity : Entity
{   
    private readonly DbSet<TEntity> dbSet = context.Set<TEntity>();
    protected AppDbContext Context { get; } = context;

    public virtual IQueryable<TEntity> Get(params string[] includeProperties)
    {
        IQueryable<TEntity> query = dbSet;

        foreach (var includeProperty in includeProperties)
            query = query.Include(includeProperty);

        return query;
    }

    public virtual async Task<TEntity?> GetBy(Expression<Func<TEntity, bool>> predicate)
    {
        return await dbSet.AsNoTracking().SingleAsync(predicate);
    }

    public virtual TEntity Insert(TEntity entity)
    {
        dbSet.Add(entity);

        return entity;
    }

    public virtual TEntity Update(TEntity entity)
    {   
        dbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    public virtual TEntity Delete(TEntity entity)
    {
        if (Context.Entry(entity).State == EntityState.Detached)
            dbSet.Attach(entity);

        dbSet.Remove(entity);

        return entity;
    }
}