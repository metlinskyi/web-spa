
Add new migration
```dotnetcli

    dotnet ef migrations add <Name> \
        -o "TranslationManagement.Data/Management/Migrations" \
        -c "AppDbContext"  \
        -p "TranslationManagement.Data/TranslationManagement.Data.csproj"  

```

dotnet ef migrations add UserInitial \
    -o "Identity/Migrations" \
    -c "UserDbContext"  \
    -p "TranslationManagement.Data/TranslationManagement.Data.csproj" 
    -- "Data Source=TranslationIdentityDatabase.db" 

dotnet ef database update --verbose \
    --context UserDbContext \
    --project TranslationManagement.Data/TranslationManagement.Data.csproj \
    --startup-project TranslationManagement.Api/TranslationManagement.Api.csproj \
    -- "Data Source=TranslationIdentityDatabase.db" 



dotnet ef migrations add AppInitial \
    -o "Management/Migrations" \
    -c "AppDbContext"  \
    -p "TranslationManagement.Data/TranslationManagement.Data.csproj" \
    -- "Data Source=TranslationAppDatabase.db" 


dotnet ef database update --verbose \
    --context AppDbContext \
    --project TranslationManagement.Data/TranslationManagement.Data.csproj \
    --startup-project TranslationManagement.Api/TranslationManagement.Api.csproj \
    -- "Data Source=TranslationAppDatabase.db" 
