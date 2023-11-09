using Blog.Service.Services.Implementations;

namespace Blog.Gui.Other;

public class WebGuiDependencyService : DependencyService
{
    public WebGuiDependencyService(bool isDevelopment, IServiceCollection services) : base(isDevelopment)
    {
        _serviceCollection = services;
    }

    protected override void InjectAdditionalDependencies(IServiceCollection services)
    {
        
    }
}
