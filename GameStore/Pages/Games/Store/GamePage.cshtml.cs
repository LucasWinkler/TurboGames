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
    public class GamePageModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public GamePageModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(string Id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == game.CategoryId);

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