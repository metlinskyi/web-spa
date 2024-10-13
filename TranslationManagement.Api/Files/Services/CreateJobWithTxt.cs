namespace TranslationManagement.Api.Files;

using AutoMapper;
using System.IO;
using System.Threading.Tasks;

internal class CreateJobWithTxt(
    IMapper maper
    ) : IFileService
{
    public async Task<T> SaveAs<T>(Stream stream, T result)
    {
        using var reader = new StreamReader(stream);

        return maper.Map(new CreateJobWith
        {
            Content = await reader.ReadToEndAsync(),
        }, result);
    }
}