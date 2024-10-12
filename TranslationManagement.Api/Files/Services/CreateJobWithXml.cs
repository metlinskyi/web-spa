namespace TranslationManagement.Api.Files;

using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;

internal class CreateJobWithXml : IFileService
{
    private readonly IMapper maper;

    public CreateJobWithXml(IMapper maper)
    {
        this.maper = maper;
    }

    public async Task<T> SaveAs<T>(Stream stream, T result)
    {
        using var reader = new StreamReader(stream);

        var doc = XDocument.Parse(await reader.ReadToEndAsync());

        return maper.Map(new CreateJobWith
        {
            Content = doc.Root.Element("Content").Value,
            Customer = doc.Root.Element("Customer").Value.Trim()
        }, result);
    }
}