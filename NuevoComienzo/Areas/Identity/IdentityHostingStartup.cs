using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(NuevoComienzo.Areas.Identity.IdentityHostingStartup))]
namespace NuevoComienzo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}