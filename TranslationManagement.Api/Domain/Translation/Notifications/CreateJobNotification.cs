namespace TranslationManagement.Api.Domain.Translation.Notifications;

using System;
using MediatR;

public record CreateJobNotification(
    Guid Id
) : INotification;