namespace TranslationManagement.Api.Profiles;

using AutoMapper;
using Domain.Translation.Commands;
using Files;
using System;

public class CreateJobWithProfile : Profile 
{
    public CreateJobWithProfile()
    {
          CreateMap<CreateJobWith, CreateJobCommand>()

            .ForMember(command => command.Id, 
                x=>x.MapFrom(x => Guid.NewGuid()))

            .ForMember(command => command.CustomerName, opt => { 
                opt.PreCondition(src => src.Customer != null);
                opt.MapFrom(src => src.Customer);
            })

            .ForMember(command => command.OriginalContent, 
                x=>x.MapFrom(x => x.Content))                
            ;      
    }
}