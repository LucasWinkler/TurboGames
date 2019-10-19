using ConestogaVirtualGameStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ConestogaVirtualGameStore.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InfoModel Info { get; set; }

        public class InfoModel
        {
            public string Username { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string username)
        {
            var user = string.IsNullOrEmpty(username)
                ? await _userManager.GetUserAsync(User)
                : await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return RedirectToPage("/Profile/DoesNotExist");
            }

            Info = new InfoModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return Page();
        }
    }
}