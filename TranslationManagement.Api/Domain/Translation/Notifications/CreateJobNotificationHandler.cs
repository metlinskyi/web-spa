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
        logger.LogInformation($"handling notification for product creation with id : {notification.Id}. assigning stocks.");
        return Task.CompletedTask;
    }
}