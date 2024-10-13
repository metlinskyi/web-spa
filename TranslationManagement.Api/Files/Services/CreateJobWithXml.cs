namespace TranslationManagement.Api.Files;

using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;

internal class CreateJobWithXml(
    IMapper maper
    ) : IFileService
{
    public async Task<T> SaveAs<T>(Stream stream, T result)
    {
        XDocument doc = null;

        using(var reader = new StreamReader(stream))
            doc = XDocument.Parse(await reader.ReadToEndAsync());

        return maper.Map(new CreateJobWith
        {
            Content = doc.Root.Element("Content").Value,
            Customer = doc.Root.Element("Customer").Value.Trim()
        }, result);
    }
}