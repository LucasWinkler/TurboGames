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
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        public double Total { get; set; }
        public bool IsCartEmpty { get; set; }
        public List<Game> Games { get; set; }

        public IndexModel(UserManager<User> userManager, TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!await _context.HasCartAsync(user))
            {
                IsCartEmpty = true;
                return Page();
            }

            var cart = await _context.GetCartAsync(user);
            if (await _context.GetCartItemCount(cart) == 0)
            {
                IsCartEmpty = true;
                return Page();
            }

            var cartItems = _context.CartGames
                .Include(cg => cg.Game)
                .ThenInclude(g => g.Category)
                .Where(cg => cg.CartId == cart.Id);

            Games = new List<Game>();
            foreach(var cartItem in cartItems)
            {
                var game = cartItem.Game;
                if (Games.Contains(game))
                    continue;

                Total += game.Price;
                Games.Add(game);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostProceedAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!await _context.HasCartAsync(user))
            {
                IsCartEmpty = true;
                return Page();
            }

            var cart = await _context.GetCartAsync(user);
            if (await _context.GetCartItemCount(cart) == 0)
            {
                IsCartEmpty = true;
                return Page();
            }

            var cartItems = _context.CartGames
               .Include(cg => cg.Game)
               .ThenInclude(g => g.Category)
               .Where(cg => cg.CartId == cart.Id);

            foreach (var cartItem in cartItems)
            {
                var game = cartItem.Game;
                Total += game.Price;
            }

        

            return RedirectToPage("./Checkout");
        }

        public async Task<IActionResult> OnPostRemoveAsync(Guid gameId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!await _context.HasCartAsync(user))
            {
                IsCartEmpty = true;
                return Page();
            }

            var cart = await _context.GetCartAsync(user);
            if (await _context.GetCartItemCount(cart) == 0)
            {
                IsCartEmpty = true;
                return Page();
            }

            var cartItems = _context.CartGames
                .Include(cg => cg.Game)
                .ThenInclude(g => g.Category)
                .Where(cg => cg.CartId == cart.Id);

            try
            {
                var cartGame = await cartItems.FirstOrDefaultAsync(ci => ci.GameId == gameId && ci.Cart == cart);
                _context.CartGames.Remove(cartGame);

                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return RedirectToPage();
        }
    }
}