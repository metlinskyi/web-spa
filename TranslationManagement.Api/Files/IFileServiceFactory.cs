namespace TranslationManagement.Api.Files;

public interface IFileServiceFactory 
{
    IFileService Create(string type);
}