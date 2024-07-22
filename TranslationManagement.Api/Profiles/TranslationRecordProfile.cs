namespace TranslationManagement.Api.Profiles;

using AutoMapper;
using Data.Management;
using Models;
using System;

public class TranslationRecordProfile : Profile 
{
    public TranslationRecordProfile()
    {
        CreateMap<TranslationJobModel, JobRecrod>()

            .ForMember(record => record.Id, 
                x=>x.MapFrom(model => !string.IsNullOrEmpty(model.Id) ? Guid.Parse(model.Id) : Guid.NewGuid()))

            .ForMember(record => record.Status, 
                x=>x.MapFrom(model => Enum.Parse<JobStatus>(model.Status)))
            ;

        CreateMap<TranslationJobModel, TranslationRecord>()

            .ForMember(record => record.Id, 
                x=>x.MapFrom(model => !string.IsNullOrEmpty(model.Id) ? Guid.Parse(model.Id) : Guid.NewGuid()))

            .ForMember(record => record.OriginalContent, 
                x=>x.MapFrom(model => model.OriginalContent))

            .ForMember(record => record.TranslatedContent, 
                x=>x.MapFrom(model => model.TranslatedContent))

            .ForMember(record => record.CustomerName, 
                x=>x.MapFrom(model => model.CustomerName))

            .ForMember(record => record.Price, 
                x=>x.MapFrom(model => model.Price))
            ;

        CreateMap<TranslationRecord, TranslationJobModel>()

            .ForMember(model => model.Id,
                x => x.MapFrom(record => record.Id.ToString()))

            .ForMember(model => model.OriginalContent, 
                x=>x.MapFrom(record => record.OriginalContent))

            .ForMember(model => model.TranslatedContent, 
                x=>x.MapFrom(record => record.TranslatedContent))

            .ForMember(model => model.Price, 
                x=>x.MapFrom(record => record.Price))              
            ;    
    }
}