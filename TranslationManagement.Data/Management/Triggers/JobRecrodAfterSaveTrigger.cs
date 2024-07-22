using EntityFrameworkCore.Triggered;
using Microsoft.Extensions.Logging;
using TranslationManagement.Data.Management;

public class JobRecrodAfterSaveTrigger : IAfterSaveTrigger<JobRecrod>
{
    private readonly INotification<JobRecrod> _jobNotification;
    private readonly ILogger<JobRecrodAfterSaveTrigger> _logger;

    public JobRecrodAfterSaveTrigger(
        INotification<JobRecrod> jobNotification,
        ILogger<JobRecrodAfterSaveTrigger> logger)
    {
        _jobNotification = jobNotification;
        _logger = logger;
    }
    public async Task AfterSave(ITriggerContext<JobRecrod> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == ChangeType.Added)
        {       
            try
            {
                await _jobNotification.Send(context.Entity);
            }
            catch(ApplicationException x)
            {
                _logger.LogError(x.Message);
            }
        }
    }
}