using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GameStore.Pages.Identity.IdentityHostingStartup))]
namespace GameStore.Pages.Identity
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