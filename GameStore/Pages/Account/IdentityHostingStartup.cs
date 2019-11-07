using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GameStore.Pages.Account.IdentityHostingStartup))]
namespace GameStore.Pages.Account
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