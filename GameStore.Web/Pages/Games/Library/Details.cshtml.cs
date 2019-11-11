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

namespace GameStore.Web.Pages.Games.Library
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public DetailsModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public UserGame UserGame { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (id == null)
            {
                return RedirectToPage("/Games/Library/Index");
            }

            UserGame = await _context.UserGame
                .Include(u => u.Game)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);

            if (UserGame == null)
            {
                return RedirectToPage("/Games/Library/Index");
            }

            return Page();
        }
    }
}
