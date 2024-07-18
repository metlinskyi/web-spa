using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TranslationManagement.Data.Identity;

internal class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
}