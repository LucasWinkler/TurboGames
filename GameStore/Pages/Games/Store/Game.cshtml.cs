using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Pages.Games.Store
{
    public class GameModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameModel(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(string Id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var game = await _context.Game.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            var category = await _context.Category.FirstOrDefaultAsync(x => x.Id == game.CategoryId);

            Game = new Game
            {
                Title = game.Title,
                Developer = game.Developer,
                TotalRating = game.TotalRating,
                Category = category,
                Reviews = game.Reviews
            };

            return Page();
        }
    }
}