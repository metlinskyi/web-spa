namespace TranslationManagement.Data.Access;

using Microsoft.EntityFrameworkCore;
using Data.Management;

internal class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{   
    private readonly AppDbContext context;
    private readonly DbSet<TEntity> dbSet;
    public Repository(AppDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> Get(params string[] includeProperties)
    {
        IQueryable<TEntity> query = dbSet;

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return query;
    }

    public virtual TEntity? GetByID(Guid id)
    {
        return dbSet.AsNoTracking().Single(x=>x.Id == id);
    }

    public virtual Task<TEntity?> GetByIDAsync(Guid id)
    {
        return dbSet.FindAsync(id).AsTask();
    }

    public virtual void Insert(TEntity entity)
    {
        dbSet.Add(entity);
    }

    public virtual Task InsertAsync(TEntity entity)
    {
       return dbSet.AddAsync(entity).AsTask();
    }

    public virtual void Delete(Guid id)
    {
        TEntity? entityToDelete = GetByID(id);
        if(entityToDelete != null)
        {
            Delete(entityToDelete);
        }
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {   
        if (context.Entry(entityToUpdate).State == EntityState.Detached)
        {
            dbSet.Attach(entityToUpdate);
        }

        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}