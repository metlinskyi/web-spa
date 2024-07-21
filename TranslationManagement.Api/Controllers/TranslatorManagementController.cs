namespace TranslationManagement.Api.Controlers;

using Asp.Versioning;
using AutoMapper;
using Data;
using Data.Management;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Linq;
using System.Threading.Tasks;

[ApiVersion(1.0)]
[ApiRoute("TranslatorsManagement/[action]")]
public class TranslatorManagementController : ApiController
{
    public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };
    private readonly ILogger<TranslatorManagementController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TranslatorManagementController(
        ILogger<TranslatorManagementController> logger,
        IUnitOfWork unitOfWork,
        IMapper mapper) 
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public TranslatorModel[] GetTranslators()
    {
        return _unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .Get()
            .Select(_mapper.Map<TranslatorRecord, TranslatorModel>)
            .ToArray();
    }

    [HttpGet]
    public TranslatorModel[] GetTranslatorsByName(string name)
    {
        return _unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .Get()
            .Where(t => t.Name == name)
            .Select(_mapper.Map<TranslatorRecord, TranslatorModel>)
            .ToArray();
    }

    [HttpPost]
    public async Task<bool> AddTranslator(TranslatorModel translator)
    {
        var record = _mapper.Map<TranslatorModel, TranslatorRecord>(translator);

        await _unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .InsertAsync(record);

        return await _unitOfWork.SaveAsync() > 0;
    }
    
    [HttpPost]
    public string UpdateTranslatorStatus(string translatorId, string newStatus = "")
    {
        _logger.LogInformation("User status update request: " + newStatus + " for user " + translatorId.ToString());
        
        TranslatorStatus status = Enum.Parse<TranslatorStatus>(newStatus);
        if (status == TranslatorStatus.Default)
        {
            throw new ArgumentException("unknown status");
        }

        Guid id = Guid.Parse(translatorId);
        var repository = _unitOfWork.RepositoryFor<TranslatorRecord>();
        var translator = repository
            .GetByID(id);

        if(translator == null)
        {
           throw new EntityException<TranslatorRecord>(translator, "Not Found!");
        }

        translator = translator with 
        {
            Status = status
        };

        repository.Update(translator);

        return _unitOfWork.Save() > 0 
            ? "updated" 
            : throw new EntityException<TranslatorRecord>(translator, "Cannnot Update!");
    }
}
