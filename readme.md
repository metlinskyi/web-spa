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
dotnet run --project TranslationManagement.Api/TranslationManagement.Api.csproj
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
