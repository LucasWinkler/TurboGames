using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Games
{
    [Authorize]
    public class GameDetailsModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public GameDetailsModel(
            UserManager<User> userManager,
            TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public IList<Review> Reviews { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Game = await _context.Game
                .Include(x => x.Category)
                .Include(x => x.Reviews)
                .Include(x => x.Platform)
                .FirstOrDefaultAsync(x => x.Id == id);

            Reviews = _context.Review
                .Include(x => x.Game)
                .Include(x => x.Reviewer)
                .Where(x => x.IsAccepted && x.GameId == id).ToList();

            return Page();
        }
    }
}