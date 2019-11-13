using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Models;
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
                foreach (var review in _context.Reviews.Include(x => x.Game)
                    .Where(x => x.GameId == game.Id))
                {
                    game.TotalRating += review.Rating;
                }
            }

            Games = await games.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAddItemToCartAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCheckedOut);
            if (cart == null)
            {
                try
                {
                    cart = new ShoppingCart
                    {
                        UserId = user.Id
                    };

                    await _context.AddAsync(cart);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException);
                }
            }

            var gameToAdd = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            var isGameAdded = await _context.CartGames.AnyAsync(x => x.CartId == cart.Id && x.GameId == gameToAdd.Id);
            if (isGameAdded)
            {
                StatusMessage = $"Error: This game is already in your cart.";
                return RedirectToPage();
            }

            var isGameOwned = await _context.UserGames.AnyAsync(x => x.GameId == gameToAdd.Id && x.UserId == user.Id);
            if (isGameOwned)
            {
                StatusMessage = $"Error: You already own this game.";
                return RedirectToPage();
            }

            var cartGameToAdd = new ShoppingCartGame
            {
                CartId = cart.Id,
                GameId = gameToAdd.Id,
                Price = gameToAdd.Price
            };

            try
            {
                await _context.AddAsync(cartGameToAdd);
                await _context.SaveChangesAsync();


                StatusMessage = $"'{gameToAdd.Title}' added to cart.";
                return RedirectToPage();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            StatusMessage = $"Error: An unknown error has occurred.";
            return Page();
        }
    }
}