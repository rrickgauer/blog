using BlogPilot.Services.Configs;
using BlogPilot.Services.Repository.Implementation;
using BlogPilot.Services.Repository.Interface;
using BlogPilot.Services.Repository.Other;
using BlogPilot.Services.Service.Implementation;
using BlogPilot.Services.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.Services.Injection;

public class ServicesInjector
{
    public bool IsProduction { get; private set; }
    public  IServiceCollection Services { get; private set; }

    public ServicesInjector(IServiceCollection services, bool isProduction)
    {
        Services = services;
        IsProduction = isProduction;
    }


    public void InjectDependencies()
    {
        // set the appropriate configuration class
        // depends if the app is running in development or production
        if (IsProduction)
        {
            Services.AddSingleton<IConfigs, ConfigsProduction>();
        }
        else
        {
            Services.AddSingleton<IConfigs, ConfigsDev>();
        }


        // services
        Services.AddSingleton<IModelMapperService, ModelMapperService>();
        Services.AddSingleton<IEntryService, EntryService>();
        Services.AddSingleton<IWebService, WebService>();

        // repositories
        Services.AddSingleton<IEntryRepository, EntryRepository>();
        
        // other
        Services.AddTransient<DbConnection>();
    }
}
