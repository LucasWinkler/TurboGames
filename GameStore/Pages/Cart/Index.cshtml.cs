using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public double Total { get; set; }

        public IndexModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<Game> Games { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var cart = await _context.Cart.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCheckedOut);
            if (cart == null)
            {
                StatusMessage = $"Error: You must have items in your cart.";
                return RedirectToPage();
            }

            var cartGames = _context.CartGame.Include(x => x.Game).Where(x => x.CartId == cart.Id);
            if (cartGames == null)
            {
                StatusMessage = $"Error: You must have items in your cart.";
                return RedirectToPage();
            }

            Games = new List<Game>();
            foreach(var item in cartGames)
            {
                var game = item.Game;
                if (Games.Contains(game)) 
                    continue;

                Total += game.Price;
                Games.Add(game);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCheckedOut);
            if (cart == null)
            {
                StatusMessage = $"Error: You must have items in your cart.";
                return RedirectToPage();
            }

            var cartGames = _context.CartGame.Where(x => x.CartId == cart.Id);
            if (cartGames == null)
            {
                StatusMessage = $"Error: You must have items in your cart.";
                return RedirectToPage();
            }

            var address = await _context.Address.FirstOrDefaultAsync(x => x.Id == user.AddressId);
            var payment = await _context.Payment.FirstOrDefaultAsync(x => x.Id == user.PaymentId);
            if (address == null || payment == null)
            {
                StatusMessage = $"Error: You must have both payment and address information. Please go to your account settings.";
                return RedirectToPage();
            }

            cart.IsCheckedOut = true;

            try
            {
                _context.Update(cart);

                await _context.SaveChangesAsync();

                StatusMessage = $"Success: You have purchased {cartGames.Count()} game(s)!";
                return RedirectToPage();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }
    }
}