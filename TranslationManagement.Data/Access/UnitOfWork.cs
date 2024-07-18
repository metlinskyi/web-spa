namespace TranslationManagement.Data.Access;

using Management;

internal class UnitOfWork : IUnitOfWork
{
    private readonly object _locker = new object();
    private bool _disposed = false;
    private readonly IDictionary<Type, IRepository> _repositories;
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {       
        _repositories = new Dictionary<Type, IRepository>();
        _context = context;
    }

    public IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : Entity
    {

        if(!_repositories.TryGetValue(typeof(TEntity), out IRepository repository))
        {
            repository = new Repository<TEntity>(_context);
            if(!_repositories.TryAdd(typeof(TEntity), repository))
            {
                throw new EntityException("Cannot add repository");
            }
        }

        return (IRepository<TEntity>) repository;
    }

    public int Save()
    {
       return _context.SaveChanges();
    }

    public Task<int> SaveAsync()
    {
       return _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}