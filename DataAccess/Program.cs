// Configure database

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using pisLab1;

var dbBuilder = new ConfigurationBuilder();
dbBuilder.SetBasePath(Directory.GetCurrentDirectory());
dbBuilder.AddJsonFile("appsettings.json");
var config = dbBuilder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<SpyContext.ApplicationContext>();
SpyContext.Options = optionsBuilder.UseSqlServer(connectionString).Options;