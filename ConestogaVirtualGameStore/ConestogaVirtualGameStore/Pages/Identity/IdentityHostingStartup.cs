using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ConestogaVirtualGameStore.Pages.Identity.IdentityHostingStartup))]
namespace ConestogaVirtualGameStore.Pages.Identity
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