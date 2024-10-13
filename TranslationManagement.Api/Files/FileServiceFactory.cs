namespace TranslationManagement.Api.Files;

using System;
using Microsoft.Extensions.DependencyInjection;

internal class FileServiceFactory(
    IServiceProvider provider
    ) : IFileServiceFactory
{
    public IFileService Create(string type)
    {
        return provider.GetKeyedService<IFileService>(type.ToLower()) 
            ?? throw new NotSupportedException(type);
    }
}