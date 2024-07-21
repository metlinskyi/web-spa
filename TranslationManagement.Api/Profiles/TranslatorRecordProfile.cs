namespace TranslationManagement.Api.Profiles;

using AutoMapper;
using Data.Management;
using Models;
using System;

public class TranslatorRecordProfile : Profile 
{
    public TranslatorRecordProfile()
    {
        CreateMap<TranslatorModel, TranslatorRecord>()  

           .ForMember(record => record.Id, 
                x=>x.MapFrom(model => string.IsNullOrEmpty(model.Id) ? Guid.Parse(model.Id) : Guid.NewGuid()))

           .ForMember(record => record.Name, 
                x=>x.MapFrom(model => model.Name))

           .ForMember(record => record.HourlyRate, 
                x=>x.MapFrom(model => model.HourlyRate))

            .ForMember(record => record.CreditCardNumber, 
                x=>x.MapFrom(model => model.CreditCardNumber))   

            .ForMember(record => record.Status, 
                x=>x.MapFrom(model => Enum.Parse<TranslatorStatus>(model.Status)))     
            ;

        CreateMap<TranslatorRecord, TranslatorModel>()  

            .ForMember(model => model.Id, 
                x=>x.MapFrom(record => record.Id.ToString()))    

            .ForMember(model => model.Status, 
                x=>x.MapFrom(record => record.Status.ToString()))    
            ;        
    }
}