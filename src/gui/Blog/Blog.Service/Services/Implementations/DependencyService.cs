using Blog.Service.Domain.Configs;
using Blog.Service.Repository.Contracts;
using Blog.Service.Repository.Implementations;
using Blog.Service.Repository.Other;
using Blog.Service.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Implementations;

public abstract class DependencyService
{
    protected abstract void InjectAdditionalDependencies(IServiceCollection services);

    public bool IsDevelopment { get; protected set; } = false;

    protected IServiceCollection _serviceCollection = new ServiceCollection();

    public DependencyService(bool isDevelopment)
    {
        IsDevelopment = isDevelopment;
    }

    public virtual IServiceCollection BuildServices()
    {
        InjectConfig();

        InjectEssentialServices();

        InjectAdditionalDependencies(_serviceCollection);

        return _serviceCollection;
    }

    protected void InjectConfig()
    {
        // set the appropriate configuration class
        // depends if the app is running in development or production
        if (IsDevelopment)
        {
            _serviceCollection.AddSingleton<IConfigs, ConfigurationDev>();
        }
        else
        {
            _serviceCollection.AddSingleton<IConfigs, ConfigurationProduction>();
        }
    }

    protected virtual void InjectEssentialServices()
    {
        _serviceCollection
            .AddScoped<IEntryService, EntryService>()
            .AddScoped<ITopicService, TopicService>()

            .AddSingleton<ITableMapperService, TableMapperService>()
            
            .AddScoped<IEntryRepository, EntryRepository>()
            .AddScoped<ITopicRepository, TopicRepository>()
            
            .AddTransient<DatabaseConnection>();
    }
}
