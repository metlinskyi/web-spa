#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN dotnet tool install --global dotnet-ef --version 6.0.32
RUN dotnet tool install --global Swashbuckle.AspNetCore.Cli --version 6.4.0
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef --version

WORKDIR /src
COPY . .
RUN dotnet restore "TranslationManagement.Api/TranslationManagement.Api.csproj"
RUN dotnet build "TranslationManagement.Api/TranslationManagement.Api.csproj" -c Release -o /app/build
RUN dotnet ef migrations bundle \
    -p TranslationManagement.Data/TranslationManagement.Data.csproj \
    -c UserDbContext -o /app/user.context -f \
    -- "Data Source=TranslationIdentityDatabase.db" 
RUN dotnet ef migrations bundle \
    -p TranslationManagement.Data/TranslationManagement.Data.csproj \
    -c AppDbContext -o /app/app.context -f \
    -- "Data Source=TranslationAppDatabase.db"


FROM build AS publish
RUN dotnet publish "TranslationManagement.Api/TranslationManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /app/user.context user.context
COPY --from=publish /app/app.context app.context
RUN ./user.context -- "Data Source=TranslationIdentityDatabase.db"
RUN ./app.context -- "Data Source=TranslationAppDatabase.db" 

ENTRYPOINT ["dotnet", "TranslationManagement.Api.dll"]