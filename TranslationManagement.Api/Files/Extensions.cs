namespace TranslationManagement.Api.Files;

using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddFileServices(this IServiceCollection _)
    {
        return _
                .AddScoped<IFileServiceFactory, FileServiceFactory>()
                .AddKeyedTransient<IFileService, CreateJobWithTxt>("txt")
                .AddKeyedTransient<IFileService, CreateJobWithXml>("xml")
                ;
    }
}