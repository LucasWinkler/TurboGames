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
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Games
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public DetailsModel(
            UserManager<User> userManager,
            TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public Game Game { get; set; }

        public bool IsOwned { get; set; }

        public IList<Review> Reviews { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            GetGameDetails(id);

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

            var gameToAdd = await _context.Games.Include(x => x.Platform).Include(x => x.Category).Include(x => x.Reviews).FirstOrDefaultAsync(x => x.Id == id);
            var isGameAdded = await _context.CartGames.AnyAsync(x => x.CartId == cart.Id && x.GameId == gameToAdd.Id);
            if (isGameAdded)
            {
                StatusMessage = $"Error: This game is already in your cart.";

                return await OnGetAsync(id);
            }

            var isGameOwned = await _context.UserGames.AnyAsync(x => x.GameId == gameToAdd.Id && x.UserId == user.Id);
            if (isGameOwned)
            {
                StatusMessage = $"Error: You already own this game.";
                return await OnGetAsync(id);
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
                return await OnGetAsync(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            StatusMessage = $"Error: An unknown error has occurred.";
            return Page();
        }

        private void GetGameDetails(Guid id)
        {
            Game = _context.Games
                .Include(x => x.Category)
                .Include(x => x.Reviews)
                .Include(x => x.Platform)
                .FirstOrDefault(x => x.Id == id);

            Reviews = _context.Reviews
                .Include(x => x.Game)
                .Include(x => x.Reviewer)
                .Where(x => x.IsAccepted && x.GameId == id).ToList();

            IsOwned = _context.UserGames.Any(x => x.GameId == id);
        }
    }
}