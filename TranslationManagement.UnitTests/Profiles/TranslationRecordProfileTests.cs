namespace TranslationManagement.UnitTests.Payments;

using Api.Models;
using Api.Profiles;
using AutoMapper;
using Data.Management;
using NUnit.Framework;
using System;

public class TranslationRecordProfileTests
{
    [TestCase(
        "c569fd34-1ae8-488b-91f3-5eff857f85e9",
        "034c0409-ccfc-4ee7-a10b-ea003767478d",
        "Original Content",
        "Translated Content",
        0.0)]
    public void Test1(string id, string customerId, string originalContent, string translatedContent, decimal price)
    {
        var mappingProfile = new TranslationRecordProfile();
        var mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(mappingProfile);
        }));

        var record = new TranslationRecord(
            Guid.Parse(id),
            originalContent,
            translatedContent);
        record = record with{
            Price = price
        };

        var model = mapper.Map<TranslationRecord, TranslationJobModel>(record);

        Assert.That(model.Id == record.Id.ToString());
        Assert.That(model.OriginalContent == record.OriginalContent);   
        Assert.That(model.TranslatedContent == record.TranslatedContent);  
    }
}