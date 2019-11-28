using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GameStore.Web.Pages.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public IndexModel(
            UserManager<User> userManager,
            TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<User> Users { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            IQueryable<User> users = _context.Users
                .Include(x => x.FavouritePlatform)
                .Include(x => x.FavouriteCategory);
            
            if (!string.IsNullOrEmpty(Search))
            {
                users = users.Where(x => x.UserName.Contains(Search.Trim()));
            }

            Users = await users.ToListAsync();

            return Page();
        }
    }
}
