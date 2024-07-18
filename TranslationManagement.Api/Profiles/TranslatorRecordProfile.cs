using AutoMapper;

namespace TranslationManagement.Api.Profiles;
using Data.Management;
using Models;

public class TranslatorRecordProfile : Profile 
{
    public TranslatorRecordProfile()
    {
        CreateMap<TranslatorRecord, TranslatorModel>();
    }
}