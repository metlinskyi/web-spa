namespace TranslationManagement.Data.Management;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

internal class AppDbFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(args[0]);
        return new AppDbContext(optionsBuilder.Options);
    }
}