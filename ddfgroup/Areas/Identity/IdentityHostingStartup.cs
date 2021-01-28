using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ddfgroup.Areas.Identity.IdentityHostingStartup))]
namespace ddfgroup.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}