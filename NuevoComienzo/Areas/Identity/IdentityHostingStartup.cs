using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuevoComienzo.Models;

[assembly: HostingStartup(typeof(NuevoComienzo.Areas.Identity.IdentityHostingStartup))]
namespace NuevoComienzo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthenticationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthenticationContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>()
                  //  .AddEntityFrameworkStores<AuthenticationContext>();
            });
        }
    }
}