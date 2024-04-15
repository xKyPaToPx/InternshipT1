using Microsoft.EntityFrameworkCore;
using pisLab1;
using pisLab1.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Configure database
var dbBuilder = new ConfigurationBuilder();
dbBuilder.SetBasePath(Directory.GetCurrentDirectory());
dbBuilder.AddJsonFile("appsettings.json");
var config = dbBuilder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<DataBase.ApplicationContext>();
DataBase.Options = optionsBuilder.UseSqlServer(connectionString).Options;


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();