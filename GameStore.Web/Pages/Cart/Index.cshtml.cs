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

namespace GameStore.Web.Pages.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public double Total { get; set; }

        public IndexModel(UserManager<User> userManager, TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<Game> Games { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return NotFound("Under construction");

#pragma warning disable CS0162 // Unreachable code detected
            var user = await _userManager.GetUserAsync(User);
#pragma warning restore CS0162 // Unreachable code detected
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCheckedOut);
            if (cart == null)
            {
                StatusMessage = $"Error: You must have items in your cart.";
                return RedirectToPage("/Games/Store/Index");
            }

            var cartGames = _context.CartGames.Include(x => x.Game).Where(x => x.CartId == cart.Id);
            if (cartGames == null)
            {
                StatusMessage = $"Error: You must have items in your cart.";
                return RedirectToPage("/Games/Store/Index");
            }

            Games = new List<Game>();
            foreach (var item in cartGames)
            {
                var game = item.Game;
                if (Games.Contains(game))
                    continue;

                Total += game.Price;
                Games.Add(game);
            }

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return RedirectToPage("/Account/Login");
        //    }

        //    var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCheckedOut);
        //    if (cart == null)
        //    {
        //        StatusMessage = $"Error: You must have items in your cart.";
        //        return RedirectToPage();
        //    }

        //    var cartGames = _context.CartGames.Include(x => x.Game).Where(x => x.CartId == cart.Id);
        //    if (cartGames == null)
        //    {
        //        StatusMessage = $"Error: You must have items in your cart.";
        //        return RedirectToPage();
        //    }

        //    var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == user.BillingAddressId);
        //    var payment = await _context.Payment.FirstOrDefaultAsync(x => x.Id == user.PaymentId);
        //    if (address == null || payment == null)
        //    {
        //        StatusMessage = $"Error: You must have both payment and address information. Please go to your account settings.";
        //        return RedirectToPage();
        //    }

        //    foreach (var item in cartGames)
        //    {
        //        var game = item.Game;
        //        var userGames = await _context.UserGames.Where(x => x.GameId == game.Id && x.UserId == user.Id).ToListAsync();

        //        if (userGames.Count != 0)
        //        {
        //            StatusMessage = $"Error: You already own at least one of these games.";
        //            return RedirectToPage();
        //        }
        //    }

        //    try
        //    {
        //        cart.IsCheckedOut = true;
        //        _context.Update(cart);

        //        await _context.SaveChangesAsync();

        //        foreach (var item in cartGames)
        //        {
        //            await _context.AddAsync(new UserGame
        //            {
        //                GameId = item.Game.Id,
        //                UserId = user.Id
        //            });
        //        }

        //        await _context.SaveChangesAsync();

        //        StatusMessage = $"Success: You have purchased {cartGames.Count()} game(s)!";
        //        return RedirectToPage("/Games/Library/Index");
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.InnerException);
        //    }

        //    return Page();
        //}
    }
}