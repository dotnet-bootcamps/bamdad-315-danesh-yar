using App.EndPoints.TicketingUI.StartupExtensions;
using App.Infrastructures.Db.SqlServer.Ef.DbCtxs;
using Bamdad.Framework.Web.ExceptionHandling;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Configuration = new NLogLoggingConfiguration(builder.Configuration.GetSection("NLog"));
var logger = NLogBuilder.ConfigureNLog(LogManager.Configuration).GetCurrentClassLogger();

#region NLog
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
#endregion MyRegion



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureServices(builder.Configuration);


var app = builder.Build();


app.Use_ExceptionHandler();
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    using (var context = scope.ServiceProvider.GetService<AppDbContext>())
        context.Database.Migrate();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
