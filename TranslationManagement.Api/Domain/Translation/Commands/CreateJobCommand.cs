namespace TranslationManagement.Api.Domain.Translation.Commands;

using MediatR;
using System;

public record CreateJobCommand(
    string Id,
    string CustomerName,
    string Status,
    string OriginalContent,
    string TranslatedContent,
    decimal Price
) : IRequest<Guid>;