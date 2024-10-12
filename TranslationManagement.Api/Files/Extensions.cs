namespace TranslationManagement.Api.Files;

using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddFileServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IFileServiceFactory, FileServiceFactory>()
            .AddKeyedTransient<IFileService, CreateJobWithTxt>("txt")
            .AddKeyedTransient<IFileService, CreateJobWithXml>("xml");
    }
}