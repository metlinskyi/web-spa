namespace TranslationManagement.Data;

using Access;
using EntityFrameworkCore.Triggered;
using Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddDb(this IServiceCollection _, string connectionString)
    {
        return _
                .AddDbContext<AppDbContext>(options => {
                    options.UseSqlite(connectionString);
                    options.UseTriggers();
                })
                .AddScoped<IAfterSaveTrigger<JobRecrod>, JobRecrodAfterSaveTrigger>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                ;
    }

    public static IServiceCollection AddDbIdentity(this IServiceCollection _, string connectionString)
    {
        return _
                .AddDbContext<AppDbContext>(options => 
                    options.UseSqlite(connectionString))
                ;
    }
}