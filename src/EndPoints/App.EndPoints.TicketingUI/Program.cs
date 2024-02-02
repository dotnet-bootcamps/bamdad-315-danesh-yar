using App.EndPoints.TicketingUI.StartupExtensions;
using App.Infrastructures.Db.SqlServer.Ef.DbCtxs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureServices(builder.Configuration);
var app = builder.Build();
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
