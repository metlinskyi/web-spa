namespace TranslationManagement.Api.Notifications;

using Data.Management;
using External.ThirdParty.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

internal class JobNotification(
        ILogger<INotification<JobRecrod>> logger,
        INotificationService notificationService
        ) : INotification<JobRecrod>
{
    public async Task Send(JobRecrod value)
    {
        while (! await notificationService.SendNotification("Job created: " + value.Id));
        logger.LogInformation("New job notification sent");
    }
}