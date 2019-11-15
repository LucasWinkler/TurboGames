using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GameStore.Web.Pages.Account.IdentityHostingStartup))]
namespace GameStore.Web.Pages.Account
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