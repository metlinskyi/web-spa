
# Add new migration
```dotnetcli

    dotnet ef migrations add <Name> \
        -o "Management/Migrations" \
        -c "AppDbContext"  \
        -p "TranslationManagement.Data/TranslationManagement.Data.csproj" \
        -- "Data Source=TranslationAppDatabase.db" 

    dotnet ef migrations add <Name> \
        -o "Identity/Migrations" \
        -c "UserDbContext"  \
        -p "TranslationManagement.Data/TranslationManagement.Data.csproj" 
        -- "Data Source=TranslationIdentityDatabase.db"

```

# Update db
```dotnetcli

    dotnet ef database update --verbose \
        --context AppDbContext \
        --project TranslationManagement.Data/TranslationManagement.Data.csproj \
        --startup-project TranslationManagement.Api/TranslationManagement.Api.csproj \
        -- "Data Source=TranslationAppDatabase.db" 
    
    dotnet ef database update --verbose \
        --context UserDbContext \
        --project TranslationManagement.Data/TranslationManagement.Data.csproj \
        --startup-project TranslationManagement.Api/TranslationManagement.Api.csproj \
        -- "Data Source=TranslationIdentityDatabase.db" 
```
