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

        public async Task<IActionResult> OnPostCartAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var game = await _context.GetGameAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            if (await _context.DoesUserOwnGameAsync(user, game))
            {
                StatusMessage = $"Error: You already own this game.";
                return RedirectToPage();
            }

            var cart = await _context.GetCartAsync(user);
            if (cart == null)
            {
                StatusMessage = $"Error: An error occurred while getting your cart.";
                return RedirectToPage();
            }

            if (await _context.DoesGameExistInCartAsync(cart, game))
            {
                StatusMessage = $"Error: This game is already in your cart.";
                return RedirectToPage();
            }

            if (await _context.AddToCartAsync(cart, game))
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

        public async Task<IActionResult> OnPostWishlistAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var game = await _context.GetGameAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            if (await _context.DoesUserOwnGameAsync(user, game))
            {
                StatusMessage = $"Error: You already own this game.";
                return RedirectToPage();
            }

            var wishlist = await _context.GetWishlistAsync(user);
            if (wishlist == null)
            {
                StatusMessage = $"Error: An error occurred while getting your wishlist.";
                return RedirectToPage();
            }

            if (await _context.DoesGameExistInWishlistAsync(wishlist, game))
            {
                StatusMessage = $"Error: This game is already on your wishlist.";
                return RedirectToPage();
            }

            if (await _context.AddToWishlistAsync(wishlist, game))
            {
                StatusMessage = $"'{game.Title}' has been added to your wishlist.";
                return RedirectToPage();
            }
            else
            {
                StatusMessage = $"Error: We were unable to add that game to your wishlist.";
                return RedirectToPage();
            }
        }
    }
}