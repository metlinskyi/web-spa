# Run for dev
```dotnetcli
    dotnet run --project TranslationManagement.Api/TranslationManagement.Api.csproj
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
docker run -d --hostname web \
    --name tm-web \
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
