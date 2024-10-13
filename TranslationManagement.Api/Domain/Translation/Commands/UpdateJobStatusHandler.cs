namespace TranslationManagement.Api.Domain.Translation.Commands;

using Data.Management;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class UpdateJobStatusHandler(
    AppDbContext context
    ) : IRequestHandler<UpdateJobStatusCommand, string>
{
    public async Task<string> Handle(UpdateJobStatusCommand command, CancellationToken cancellationToken)
    {
        var translator = await context.Translators
            .Where(x => x.Id == command.TranslatorId && x.Status == TranslatorStatus.Certified)
            .SingleOrDefaultAsync();

        if(translator == null)
        {
            throw new ArgumentException($"The translator must be {TranslatorStatus.Certified}!");     
        }

        var job = await context.Jobs
            .Where(x => x.Id == command.JobId)
            .SingleOrDefaultAsync();

        bool isInvalidStatusChange = (job.Status == JobStatus.New && command.Status == JobStatus.Completed) ||
                                        job.Status == JobStatus.Completed || command.Status == JobStatus.New;
        if (isInvalidStatusChange)
        {
            throw new ArgumentException("invalid status change");
        }

        context.Jobs.Update(job with
        {
            Status = command.Status
        });

        await context.SaveChangesAsync();
        
        return "updated";
    }
}