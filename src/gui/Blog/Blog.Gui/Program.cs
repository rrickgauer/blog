using Blog.Gui.Other;

var builder = WebApplication.CreateBuilder(args);


var isDevelopment = !builder.Environment.IsProduction();
WebGuiDependencyService serviceInjector = new(isDevelopment, builder.Services);
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







