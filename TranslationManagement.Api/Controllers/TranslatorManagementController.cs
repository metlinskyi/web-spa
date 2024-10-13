namespace TranslationManagement.Api.Controlers;

using Asp.Versioning;
using AutoMapper;
using Data;
using Data.Management;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiVersion(1.0)]
[ApiRoute("TranslatorsManagement/[action]")]
public class TranslatorManagementController(
        ILogger<TranslatorManagementController> logger,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : ApiController
{
    public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };

    [HttpGet]
    public async Task<IEnumerable<TranslatorModel>> GetTranslators()
    {
        return (await unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .Get()
            .ToArrayAsync())
            .Select(mapper.Map<TranslatorRecord, TranslatorModel>);
    }

    [HttpGet]
    public async Task<IEnumerable<TranslatorModel>> GetTranslatorsByName(string name)
    {
        return (await unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .Get()
            .Where(t => t.Name == name)
            .ToArrayAsync())
            .Select(mapper.Map<TranslatorRecord, TranslatorModel>);
    }

    [HttpPost]
    public async Task<string> AddTranslator(TranslatorModel translator)
    {
        var record = mapper.Map<TranslatorModel, TranslatorRecord>(translator);

        unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .Insert(record);

        return await unitOfWork.Save() > 0 
            ? record.Id.ToString() 
            : throw new EntityException<TranslatorRecord>(record, "Cannnot Update!");
    }
    
    [HttpPost]
    public async Task<string> UpdateTranslatorStatus(string translatorId, string newStatus = "")
    {
        logger.LogInformation("User status update request: " + newStatus + " for user " + translatorId.ToString());
        
        var id = Guid.Parse(translatorId);
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid format", nameof(translatorId));

        var status = Enum.Parse<TranslatorStatus>(newStatus);
        if (status == TranslatorStatus.Default)
            throw new ArgumentException("Unknown status", nameof(newStatus));

        var repository = unitOfWork.RepositoryFor<TranslatorRecord>();
        var translator = await repository.GetBy(x=> x.Id == id);
        if (translator == null)
           throw new EntityException<TranslatorRecord>(translator, "Not Found!");

        repository.Update(translator with 
        {
            Status = status
        });

        return await unitOfWork.Save() > 0 
            ? "updated" 
            : throw new EntityException<TranslatorRecord>(translator, "Cannnot Update!");
    }
}
