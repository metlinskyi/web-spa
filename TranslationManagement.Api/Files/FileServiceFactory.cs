namespace TranslationManagement.Api.Files;

using System;
using Microsoft.Extensions.DependencyInjection;

internal class FileServiceFactory : IFileServiceFactory
{
    private readonly IServiceProvider provider;

    public FileServiceFactory(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public IFileService Create(string type)
    {
        return provider.GetKeyedService<IFileService>(type.ToLower()) 
            ?? throw new NotSupportedException(type);
    }
}