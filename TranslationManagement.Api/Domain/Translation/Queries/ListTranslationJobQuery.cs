namespace TranslationManagement.Api.Domain.Translation.Queries;

using Api.Models;
using MediatR;
using System.Collections.Generic;

public record ListTranslationJobQuery(
    
) : IRequest<IEnumerable<TranslationJobModel>>;