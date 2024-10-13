namespace TranslationManagement.Data.Access;

using Management;
using Microsoft.Extensions.DependencyInjection;

internal class UnitOfWork(
    AppDbContext context,
    IServiceProvider provider
    ) : IUnitOfWork, IDisposable
{
    public IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : Entity
    {
        return provider.GetRequiredService<IRepository<TEntity>>();
    }

    public async Task<int> Save()
    {
       return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}