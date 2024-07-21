namespace TranslationManagement.Api.Notifications;

using Data.Management;
using External.ThirdParty.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

internal class JobNotification : INotification<JobRecrod>
{
    private readonly INotificationService _notificationService;
    private readonly ILogger<INotification<JobRecrod>> _logger;

    public JobNotification(
        INotificationService notificationService,   
        ILogger<INotification<JobRecrod>> logger)
    {
        _notificationService = notificationService;
        _logger = logger;
    }

    public async Task Send(JobRecrod value)
    {
        while  (! await _notificationService.SendNotification("Job created: " + value.Id))
        {
        }

        _logger.LogInformation("New job notification sent");
    }
}