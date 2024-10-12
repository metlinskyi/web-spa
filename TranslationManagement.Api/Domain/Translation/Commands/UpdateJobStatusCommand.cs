namespace TranslationManagement.Api.Domain.Translation.Commands;

using Data.Management;
using MediatR;
using System;

public record UpdateJobStatusCommand(
    Guid JobId,
    Guid TranslatorId,
    JobStatus Status
) : IRequest<string>;