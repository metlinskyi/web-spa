namespace TranslationManagement.Data.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

internal class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
}