namespace TranslationManagement.Api.Files;

using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;

internal class CreateJobWithTxt : IFileService
{
    private readonly IMapper maper;

    public CreateJobWithTxt(IMapper maper)
    {
        this.maper = maper;
    }

    public async Task<T> SaveAs<T>(Stream stream, T result)
    {
        using var reader = new StreamReader(stream);

        return maper.Map(new CreateJobWith
        {
            Content = await reader.ReadToEndAsync(),
        }, result);
    }
}