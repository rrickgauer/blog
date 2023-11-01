using Blog.Gui.Other;
using Blog.Service.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

WebGuiDependencyService serviceInjector = new(builder.Environment.IsProduction(), builder.Services);
serviceInjector.BuildServices();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();







