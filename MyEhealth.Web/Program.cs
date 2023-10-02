using log4net;
using log4net.Config;
using System.Reflection;
using MyEhealth.Domain.Interface;
using MyEhealth.Infrastructure.Repositories;
using log4net.Core;

var builder = WebApplication.CreateBuilder(args);

var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPatientRepository, PatientRepository>();

var app = builder.Build();

//ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
//_logger.Info("TEST MESSAGE1");

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
