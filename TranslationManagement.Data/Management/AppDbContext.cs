﻿namespace TranslationManagement.Data.Management;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<JobRecrod> Jobs { get; set; }
    public DbSet<TranslationRecord> Translations { get; set; }
    public DbSet<TranslatorRecord> Translators { get; set; }
    public DbSet<PriceRecord> Prices { get; set; }
    public DbSet<CustomerRecord> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
