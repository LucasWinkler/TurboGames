using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Models;
using GameStore.Data.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Games
{
    [Authorize]
    public class StoreModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public StoreModel(
            UserManager<User> userManager,
            TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<Game> Games { get; set; }
        public IList<SelectListItem> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            IQueryable<Game> games = _context.Games
                .Include(x => x.Platform)
                .Include(x => x.Category)
                .Include(x => x.Reviews);

            IQueryable<Category> categories = _context.Categories;

            Categories = categories
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Name })
                .ToList();

            if (!string.IsNullOrEmpty(Search))
            {
                games = games.Where(x => x.Title.Contains(Search.Trim()));
            }

            if (!string.IsNullOrEmpty(Category))
            {
                games = games.Where(x => x.Category.Name.Contains(Category.Trim()));
            }

            foreach (var game in games)
            {
                game.Rating = await _context.GetTotalGameRatingAsync(game);
            }

            Games = await games.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var game = _context.GetGameAsync(id).Result;
            if (game == null)
            {
                return NotFound();
            }

            if (_context.DoesUserOwnGameAsync(user, game).Result)
            {
                StatusMessage = $"Error: You already own this game.";
                return RedirectToPage();
            }

            var cart = _context.GetCartAsync(user).Result;
            if (cart == null)
            {
                StatusMessage = $"Error: An error occurred while getting your cart.";
                return RedirectToPage();
            }

            if (_context.DoesGameExistInCartAsync(cart, game).Result)
            {
                StatusMessage = $"Error: This game is already in your cart.";
                return RedirectToPage();
            }

            if (_context.AddToCartAsync(cart, game).Result)
            {
                StatusMessage = $"'{game.Title}' has been added to your cart.";
                return RedirectToPage();
            }
            else
            {
                StatusMessage = $"Error: We were unable to add that game to your cart.";
                return RedirectToPage();
            }
        }
    }
}