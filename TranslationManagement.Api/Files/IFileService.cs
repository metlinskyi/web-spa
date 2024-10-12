namespace TranslationManagement.Api.Files;

using System.IO;
using System.Threading.Tasks;

public interface IFileService 
{
    Task<T> SaveAs<T>(Stream stream, T result);
}