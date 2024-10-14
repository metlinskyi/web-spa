namespace TranslationManagement.Api.Domain.Translation.Notifications;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

public class CreateJobNotificationHandler(
    ILogger<CreateJobNotificationHandler> logger
    ) : INotificationHandler<CreateJobNotification>
{
    public Task Handle(CreateJobNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"The notification was complited for job {notification.Id}");
        return Task.CompletedTask;
    }
}