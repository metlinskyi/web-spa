using EntityFrameworkCore.Triggered;
using TranslationManagement.Data.Management;

public class JobRecrodAfterSaveTrigger : IAfterSaveTrigger<JobRecrod>
{
    private readonly INotification<JobRecrod> _jobNotification;
    public JobRecrodAfterSaveTrigger(INotification<JobRecrod> jobNotification)
    {
        _jobNotification = jobNotification;
    }
    public async Task AfterSave(ITriggerContext<JobRecrod> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == ChangeType.Added)
        {
            await _jobNotification.Send(context.Entity);
        }
    }
}