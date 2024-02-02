using App.Infrastructures.Db.SqlServer.Ef.DbCtxs;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.TicketingUI.StartupExtensions;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
