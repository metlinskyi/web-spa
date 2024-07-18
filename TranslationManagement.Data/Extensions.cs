using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TranslationManagement.Data;

using Access;
using Management;

public static class Extensions
{
    public static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services.AddDbContext<AppDbContext>(options => {
                options.UseSqlite(connectionString);
                options.UseTriggers();
        })
        .AddTransient<IAfterSaveTrigger<JobRecrod>, JobRecrodAfterSaveTrigger>();
    }

    public static IServiceCollection AddDbIdentity(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<AppDbContext>(options => 
                options.UseSqlite(connectionString));
    }
}