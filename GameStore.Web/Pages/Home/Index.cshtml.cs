using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore.Web.Pages.Home
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public void OnGet() { }
    }
}