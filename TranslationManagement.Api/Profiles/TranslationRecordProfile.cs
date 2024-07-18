using AutoMapper;

namespace TranslationManagement.Api.Profiles;
using Data.Management;
using Models;

public class TranslationRecordProfile : Profile 
{
    public TranslationRecordProfile()
    {
        CreateMap<TranslationRecord, TranslationJobModel>();
    }
}