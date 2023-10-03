using log4net;
using log4net.Config;
using MyEhealth.Domain.Interface;
using MyEhealth.Infrastructure.Repositories;
using System.Reflection;
using log4net.Core;
using log4net.Repository;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
var builder = WebApplication.CreateBuilder(args);

//var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
//XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
//XmlConfigurator.Configure(new FileInfo("log4net.config"));
//XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"\log4net.config"));
//ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
//log4net.Config.XmlConfigurator.Configure(repository, new FileInfo(@"log4net.config"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPatientRepository, PatientRepository>();

// Log4Net
builder.Host.ConfigureLogging(log =>
{
    log.AddLog4Net("log4net.config");
    log.SetMinimumLevel(LogLevel.Warning);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
