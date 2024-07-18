using Asp.Versioning;
using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace TranslationManagement.Api.Controllers;

using Data;
using Data.Management;
using Models;
using Payments;

[ApiVersion(1.0)]
[ApiRoute("jobs/[action]")]
public class TranslationJobController : ApiController
{
    private readonly  ILogger<TranslationJobController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPriceCalculator _priceCalculator;
 
    public TranslationJobController(
        ILogger<TranslationJobController> logger,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IPriceCalculator priceCalculator) 
    {        
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _priceCalculator = priceCalculator;
    }

    [HttpGet]
    public TranslationJobModel[] GetJobs()
    {
        return _unitOfWork
            .RepositoryFor<TranslationRecord>()
            .Get(nameof(TranslationRecord.Job))
            .Select(_mapper.Map<TranslationRecord, TranslationJobModel>)
            .ToArray();
    }

    [HttpPost]
    public bool CreateJob(TranslationJobModel job)
    {
        var record = _mapper.Map<TranslationRecord>(job);
        record = record with
        {
            Price = _priceCalculator.Translation(PriceType.PerCharacter, job.OriginalContent)
        };
        
        _unitOfWork
            .RepositoryFor<TranslationRecord>()
            .Insert(record);

        return _unitOfWork.Save() > 0;
    }

    [HttpPost]
    public bool CreateJobWithFile(IFormFile file, string customer)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        string content;


        if (file.FileName.EndsWith(".txt"))
        {
            content = reader.ReadToEnd();
        }
        else if (file.FileName.EndsWith(".xml"))
        {
            var xdoc = XDocument.Parse(reader.ReadToEnd());
            content = xdoc.Root.Element("Content").Value;
            customer = xdoc.Root.Element("Customer").Value.Trim();
        }
        else
        {
            throw new NotSupportedException("unsupported file");
        }

        var newJob = new TranslationJobModel()
        {
            OriginalContent = content,
            TranslatedContent = "",
            CustomerName = customer,
        };

        return CreateJob(newJob);
    }

    [HttpPost]
    public string UpdateJobStatus(Guid jobId, Guid translatorId, JobStatus newStatus = JobStatus.Default)
    {
        _logger.LogInformation("Job status update request received: " + newStatus + " for job " + jobId.ToString() + " by translator " + translatorId);

        if (newStatus == JobStatus.Default)
        {
            throw new ArgumentException("invalid status");
        }

         var job = _unitOfWork
            .RepositoryFor<JobRecrod>()
            .GetByID(jobId);


        bool isInvalidStatusChange = (job.Status == JobStatus.New && newStatus == JobStatus.Completed) ||
                                        job.Status == JobStatus.Completed || newStatus == JobStatus.New;
        if (isInvalidStatusChange)
        {
            throw new ArgumentException("invalid status change");
        }

        job = job with
        {
            Status = newStatus
        };

        return _unitOfWork.Save() > 0 
            ? "updated" 
            : throw new EntityException<JobRecrod>(job, "Cannnot update!");
    }
}
