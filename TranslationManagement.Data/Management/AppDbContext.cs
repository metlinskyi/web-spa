namespace TranslationManagement.Data.Management;

using Microsoft.EntityFrameworkCore;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<JobRecrod> Jobs { get; set; }
    public DbSet<TranslationRecord> Translations { get; set; }
    public DbSet<TranslatorRecord> Translators { get; set; }
}
