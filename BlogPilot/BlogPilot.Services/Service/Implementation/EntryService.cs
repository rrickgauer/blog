﻿using BlogPilot.Services.Repository.Interface;
using BlogPilot.Services.Service.Interface;

namespace BlogPilot.Services.Service.Implementation;

public class EntryService : IEntryService
{
    #region - Private Members -
    private readonly IEntryRepository _entryRepository;
    private readonly IModelMapperService _mapperService;
    #endregion

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="entryRepository"></param>
    /// <param name="mapperService"></param>
    public EntryService(IEntryRepository entryRepository, IModelMapperService mapperService)
    {
        _entryRepository = entryRepository;
        _mapperService = mapperService;
    }


    public void Test() { }
}