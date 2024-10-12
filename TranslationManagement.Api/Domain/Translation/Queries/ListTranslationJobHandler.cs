namespace TranslationManagement.Api.Domain.Translation.Queries;

using Api.Models;
using AutoMapper;
using Data.Management;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class ListProductsQueryHandler(AppDbContext context, IMapper mapper) 
    : IRequestHandler<ListTranslationJobQuery, IEnumerable<TranslationJobModel>>
{
    private readonly AppDbContext context = context;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<TranslationJobModel>> Handle(ListTranslationJobQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Translations.ToArrayAsync();
        return result.Select(mapper.Map<TranslationJobModel>);
    }
}