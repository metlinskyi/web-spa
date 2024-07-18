using Microsoft.AspNetCore.Identity;

namespace TranslationManagement.Data.Identity;

public class User : IdentityUser 
{
    public Guid GetId() 
    {
        return Guid.Parse(Id);
    }
}