namespace TranslationManagement.Api.Domain.Translation.Commands;

using AutoMapper;
using Data.Management;
using MediatR;
using Payments;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateProductCommandHandler(
    AppDbContext context, 
    IMapper mapper,
    IPriceCalculator calculator
    ) : IRequestHandler<CreateJobCommand, Guid>
{
    public async Task<Guid> Handle(CreateJobCommand command, CancellationToken cancellationToken)
    {
        var record = mapper.Map<TranslationRecord>(command);
        await context.Translations.AddAsync(record = record with
        {
            Job = mapper.Map<JobRecrod>(command),
            Price = calculator.Translation(PriceType.PerCharacter, command.OriginalContent)
        });
        await context.SaveChangesAsync();
        
        return record.Id;
    }
}