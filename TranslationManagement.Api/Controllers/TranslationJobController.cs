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
public class TranslationJobController : ApiController
{
    private readonly ILogger<TranslationJobController> _logger;
    private readonly ISender _sender;
    private readonly IMediator _mediator;
    private readonly IFileServiceFactory _fileServiceFactory;

    public TranslationJobController(
        ILogger<TranslationJobController> logger,
        ISender sender,
        IMediator mediator,
        IFileServiceFactory fileServiceFactory) 
    {        
        _logger = logger;
        _sender = sender;
        _mediator = mediator;
        _fileServiceFactory = fileServiceFactory;
    }

    [HttpGet]
    public async Task<IEnumerable<TranslationJobModel>> GetJobs()
    {
        return await _sender.Send(new ListTranslationJobQuery());
    }

    [HttpPost]
    public async Task<bool> CreateJob(CreateJobCommand command)
    {
        _logger.LogInformation($"Create job for {command.CustomerName}");

        var id = await _mediator.Send(command);
        if (id == Guid.Empty) return false;
        await _mediator.Publish(new CreateJobNotification(id));

        return true;
    }

    [HttpPost]
    public async Task<bool> CreateJobWithFile(IFormFile file, string customer)
    {
        _logger.LogInformation($"Create job with file: {file.FileName}");

        var command = await _fileServiceFactory
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
        _logger.LogInformation($"Job status update request received: {newStatus} for job {jobId.ToString()} by translator {translatorId}");

        return await _mediator.Send(new UpdateJobStatusCommand(jobId, translatorId, newStatus));
    }
}