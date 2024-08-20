# Development environment

## Development tools
```dotnetcli
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 6.0.32
dotnet tool install --local Swashbuckle.AspNetCore.Cli --version 6.4.0
dotnet tool restore
```

## Run for development
```dotnetcli
dotnet build TranslationManagement.Api/TranslationManagement.Api.csproj
dotnet watch --project TranslationManagement.Api/TranslationManagement.Api.csproj
```

# Docker

## Build docker images
 ```
docker build --pull --rm -f "TranslationManagement.Api/Dockerfile" -t tm/api "."
docker build --pull --rm -f "TranslationManagement.Web/Dockerfile" -t tm/web "TranslationManagement.Web/"
```

## Initial docker command 
 ```
docker volume create tm-wwwroot
docker network create -d bridge tm-network
 ```

## Run Web UI builder
 ```
docker run -it --rm \
    --network=tm-network \
    --volume=tm-wwwroot:/app/build:rw \
    tm/web
 ```

## Run API container
 ```
docker run -d --hostname api \
    --name tm-api \
    --network=tm-network \
    --volume=tm-wwwroot:/app/wwwroot:ro \
    -p "80:80" \
    tm/api
 ```


## In conclusion 
I worked on the task for around 3.5 days. I made a design about refactoring according to the time. 

For the data access layer was applied the classical approach Unit of Work and Repository.
DB migration logic was moved to CLI tools and in the future will be added to CI/CD 
because it's more safe and manageable instead of run migration in an instance.
Just imagine when the line will be run in a multi instance environment
scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
Instead of the standalone migration script below when all instances can be controlled
 ```
RUN dotnet ef migrations bundle \
    -p TranslationManagement.Data/TranslationManagement.Data.csproj \
    -c AppDbContext -o /app/app.context -f \
    -- "Data Source=TranslationAppDatabase.db"
 ```

The UI has an auto generated API client based on an Open API schema provided by Swagger UI.
You can find it in post build events in TranslationManagement.Api.csproj
<Exec Command="dotnet swagger tofile --output ../TranslationManagement.Web/$(AssemblyName).json $(OutputPath)/$(AssemblyName).dll v1" WorkingDirectory="$(ProjectDir)" />
So, each time when a developer do changes on a backend side it reflected automatically on frontend side  
and for update the client needs to run next command in UI directory. 
npx @hey-api/openapi-ts -i TranslationManagement.Api.json -o src/api

I did not implement a lot of things like validation or DDD (I prefer this approach on the backend) because it's only for 3 days.
My development environment is Linux and VS code that's why I prefer to use CLI tools and this knowledge helps to do a good CI/CD pipeline. 


&nbsp;
============
&copy; [The Best Software Engineer In The Universe!](https://www.linkedin.com/in/metlinskyi/)

