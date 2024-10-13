namespace TranslationManagement.Api.Controllers;

using Asp.Versioning;
using Data.Management;
using Domain.Translation.Commands;
using Domain.Translation.Notifications;
using Domain.Translation.Queries;
using Files;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiVersion(1.0)]
[ApiRoute("jobs/[action]")]
public class TranslationJobController(
        ILogger<TranslationJobController> logger,
        IMediator mediator,
        IFileServiceFactory fileServiceFactory
        ) : ApiController
{
    [HttpGet]
    public async Task<IEnumerable<TranslationJobModel>> GetJobs()
    {
        return await mediator.Send(new ListTranslationJobQuery());
    }

    [HttpPost]
    public async Task<bool> CreateJob(CreateJobCommand command)
    {
        logger.LogInformation($"Create job for {command.CustomerName}");

        var id = await mediator.Send(command);
        if (id == Guid.Empty) return false;
        await mediator.Publish(new CreateJobNotification(id));

        return true;
    }

    [HttpPost]
    public async Task<bool> CreateJobWithFile(IFormFile file, string customer)
    {
        logger.LogInformation($"Create job with file: {file.FileName}");

        var command = await fileServiceFactory
            .Create(file.FileName.Split('.').Last())
            .SaveAs(file.OpenReadStream(), new CreateJobCommand(
                Guid.Empty.ToString(), 
                customer, 
                JobStatus.New.ToString(), 
                string.Empty, 
                string.Empty, 
                0));

        return await CreateJob(command);
    }

    [HttpPost]
    public async Task<string> UpdateJobStatus(Guid jobId, Guid translatorId, JobStatus newStatus = JobStatus.Default)
    {
        logger.LogInformation($"Job status update request received: {newStatus} for job {jobId.ToString()} by translator {translatorId}");

        return await mediator.Send(new UpdateJobStatusCommand(jobId, translatorId, newStatus));
    }
}