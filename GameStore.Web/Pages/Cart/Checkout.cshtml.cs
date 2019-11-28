using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Models;
using GameStore.Data.Queries;
using GameStore.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        public double Total { get; set; }
        public int CartCount { get; set; }
        public List<Game> Games { get; set; }

        [BindProperty]
        public Address Address { get; set; }

        [BindProperty]
        public Guid AddressId { get; set; }

        [BindProperty]
        public Payment Payment { get; set; }

        [BindProperty]
        public Guid PaymentId { get; set; }

        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Provinces { get; set; }
        public IList<UserAddress> Addresses { get; set; }
        public IList<Payment> Payments { get; set; }

        public CheckoutModel(UserManager<User> userManager, TurboGamesContext context)
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
                return RedirectToPage("./Index");
            }

            var cart = await _context.GetCartAsync(user);
            CartCount = await _context.GetCartItemCount(cart);
            if (CartCount == 0)
            {
                return RedirectToPage("./Index");
            }

            var cartItems = _context.CartGames
               .Include(cg => cg.Game)
               .ThenInclude(g => g.Category)
               .Where(cg => cg.CartId == cart.Id);

            Games = new List<Game>();
            foreach (var cartItem in cartItems)
            {
                var game = cartItem.Game;
                if (Games.Contains(game))
                    continue;

                Total += game.Price;
                Games.Add(game);
            }

            Countries = new List<SelectListItem>();
            Countries.AddRange(AddressHelper.GetCountries().Select(keyValue => new SelectListItem()
            {
                Value = keyValue.Key,
                Text = keyValue.Value
            }).OrderBy(x => x.Text));

            Provinces = new List<SelectListItem>();
            Provinces.AddRange(AddressHelper.GetProvinces().Select(keyValue => new SelectListItem()
            {
                Value = keyValue.Key,
                Text = keyValue.Value

            }).OrderBy(x => x.Text));

            Address = new Address();

            Addresses = await _context.UserAddresses
               .Include(x => x.User)
               .Include(x => x.Address)
               .Where(x => x.UserId == user.Id).ToListAsync();

            Payments = await _context.Payments
                .Where(x => x.Id == user.PaymentId)
                .ToListAsync();

            return Page();
        }
    }
}