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
using GameStore.Data.Queries;

namespace GameStore.Web.Pages.Wishlist
{
    [Authorize]
    public class WishlistModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public IList<WishlistGame> Games { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public WishlistModel(TurboGamesContext context, UserManager<User> userManager)
        {
             _context = context;
             _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string statusMessage)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var wishlist = await _context.GetWishlistAsync(user);
            var games = _context.WishlistGames.Include(x => x.Game).Where(x => x.WishlistId == wishlist.Id);

            if (games == null)
            {
                return Page();
            }

            if (!string.IsNullOrEmpty(Search))
            {
                games = games.Where(x => x.Game.Title.Contains(Search.Trim()));
            }

            Games = await games.ToListAsync();

            StatusMessage = !string.IsNullOrEmpty(statusMessage) ? statusMessage : "";
            return Page();
        }
    }
}
