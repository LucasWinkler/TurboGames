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

namespace GameStore.Web.Pages.Admin.Reports
{
    [Authorize(Roles = "Admin")]
    public class GameDetailsModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public GameDetailsModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Game> Games { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Games = await _context.Games
                .Include(g => g.Platform)
                .Include(g => g.Category)
                .ToListAsync();

            foreach(var game in Games)
            {
                game.Rating = await _context.GetTotalGameRatingAsync(game.Id);
            }

            return Page();
        }
    }
}