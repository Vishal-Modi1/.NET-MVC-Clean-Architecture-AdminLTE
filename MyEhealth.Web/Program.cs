using log4net;
using Microsoft.AspNetCore.Diagnostics;
using MyEhealth.Domain.Interface;
using MyEhealth.Infrastructure.Repositories;
using MyEhealth.Web.Extensions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPatientRepository, PatientRepository>();

builder.Services.AddLog4net();
builder.Host.ConfigureLogging(log =>
{
    log.AddLog4Net("log4net.config");
    log.SetMinimumLevel(LogLevel.Information);
});

ILog log = LogManager.GetLogger(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "text/html";
                            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                            if (null != exceptionObject)
                            {
                                var errorMessage = $"<b>Exception Error: {exceptionObject.Error.Message} </b> {exceptionObject.Error.StackTrace}";
                                log.Error(errorMessage);
                            }
                        });
                }
            );

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
