using Blog.Gui.Other;
using Blog.Service.Domain.Configs;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var isDevelopment = !builder.Environment.IsProduction();
WebGuiDependencyService serviceInjector = new(isDevelopment, builder.Services);

serviceInjector.BuildServices();

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();


IConfigs config = isDevelopment ? new ConfigurationDev() : new ConfigurationProduction();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownProxies.Add(IPAddress.Parse(config.VpsIdAddress));
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(config.StaticFilesPath),
});

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseForwardedHeaders();



app.Run();