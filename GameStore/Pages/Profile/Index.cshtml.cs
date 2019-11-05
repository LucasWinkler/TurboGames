using GameStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GameStore.Data.ApplicationDbContext _context;

        public IndexModel(UserManager<ApplicationUser> userManager, 
            GameStore.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public int CountGames { get; set; }

        [BindProperty]
        public InfoModel Info { get; set; }

        public class InfoModel
        {
            public string Username { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string FullName { get { return $"{FirstName} {LastName}"; } }

            public Gender Gender { get; set; }
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
                LastName = user.LastName,
                Gender = user.Gender
            };

            CountGames = _context.UserGames.Count();

            return Page();
        }
    }
}