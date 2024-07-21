namespace TranslationManagement.Data.Identity;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser 
{
    public Guid GetId() 
    {
        return Guid.Parse(Id);
    }
}