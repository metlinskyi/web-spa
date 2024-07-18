using AutoMapper;

namespace TranslationManagement.Api.Profiles;

using System;
using Data.Management;
using Models;

public class TranslationRecordProfile : Profile 
{
    public TranslationRecordProfile()
    {
        CreateMap<TranslationJobModel,TranslationRecord>()

            .ForMember(record => record.Id, 
                x=>x.MapFrom(model => string.IsNullOrEmpty(model.Id) ? Guid.Parse(model.Id) : Guid.NewGuid()))

            .ForMember(record => record.Id, 
                x=>x.MapFrom(model => Guid.Parse(model.Id)))

            .ForMember(record => record.OriginalContent, 
                x=>x.MapFrom(model => model.OriginalContent))

            .ForMember(record => record.TranslatedContent, 
                x=>x.MapFrom(model => model.TranslatedContent))
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