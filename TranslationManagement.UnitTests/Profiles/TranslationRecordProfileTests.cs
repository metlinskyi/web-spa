namespace TranslationManagement.UnitTests.Payments;

using System;
using NUnit.Framework;
using AutoMapper;
using Api.Profiles;
using Api.Models;
using Data.Management;

public class TranslationRecordProfileTests
{
    [TestCase("","","","",0.0)]
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