using GUIEX2PROJECT.Areas.Identity;
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace GUIEX2PROJECT.Areas.Identity
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