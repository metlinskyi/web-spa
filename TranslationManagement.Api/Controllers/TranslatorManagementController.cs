﻿using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace TranslationManagement.Api.Controlers;

using Data;
using Data.Management;
using Models;

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
    public bool AddTranslator(TranslatorModel translator)
    {
        var record = _mapper.Map<TranslatorModel, TranslatorRecord>(translator);

        _unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .Insert(record);

        return _unitOfWork.Save() > 0;
    }
    
    [HttpPost]
    public string UpdateTranslatorStatus(Guid translatorId, TranslatorStatus newStatus = TranslatorStatus.Default)
    {
        _logger.LogInformation("User status update request: " + newStatus + " for user " + translatorId.ToString());
        if (newStatus == TranslatorStatus.Default)
        {
            throw new ArgumentException("unknown status");
        }

        var translator = _unitOfWork
            .RepositoryFor<TranslatorRecord>()
            .GetByID(translatorId);

        translator = translator with 
        {
            Status = newStatus
        };

        return _unitOfWork.Save() > 0 
            ? "updated" 
            : throw new EntityException<TranslatorRecord>(translator, "Cannnot update!");
    }
}
