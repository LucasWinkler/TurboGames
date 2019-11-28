using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Address BillingAddress { get; set; }

        //[BindProperty]
        //public Guid BillingAddressId { get; set; }

        [BindProperty]
        public Address ShippingAddress { get; set; }

        //[BindProperty]
        //public Guid ShippingAddressId { get; set; }

        [BindProperty]
        public Payment Payment { get; set; }

        [BindProperty]
        public bool IsSameAddress { get; set; }

        //[BindProperty]
        //public Guid PaymentId { get; set; }

        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Provinces { get; set; }
        public IList<UserAddress> Addresses { get; set; }
        public IList<Payment> Payments { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

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

            if (Total == 0)
            {
                return await OnPostFreeAsync();
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

            Addresses = await _context.UserAddresses
               .Include(x => x.User)
               .Include(x => x.Address)
               .Where(x => x.UserId == user.Id).ToListAsync();

            Payments = await _context.Payments
                .Where(x => x.Id == user.PaymentId)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
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

            if (BillingAddress.Id != null && BillingAddress.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                BillingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == BillingAddress.Id);
            }

            if (ShippingAddress.Id != null && ShippingAddress.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                ShippingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == ShippingAddress.Id);
            }

            if (Payment.Id != null && Payment.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                Payment = await _context.Payments.FirstOrDefaultAsync(a => a.Id == Payment.Id);
            }

            if (IsSameAddress)
            {
                ShippingAddress = BillingAddress;
            }

            ModelState.Clear();

            if (!TryValidateModel(BillingAddress))
            {
                Debug.WriteLine("BillingAddress fail");
            }

            if (!TryValidateModel(ShippingAddress))
            {
                Debug.WriteLine("ShippingAddress fail");
            }

            if (!TryValidateModel(Payment))
            {
                Debug.WriteLine("Payment fail");
            }

            if (!ModelState.IsValid)
            {
                StatusMessage = $"Error: Unable to purchase game(s). Please check your information and try again.";
                return RedirectToPage();
            }

            var cart = await _context.GetCartAsync(user);

            CartCount = await _context.GetCartItemCount(cart);
            if (CartCount == 0)
            {
                return RedirectToPage("./Index");
            }

            var cartGames = _context.CartGames.Include(x => x.Game).Where(x => x.CartId == cart.Id);
            if (cartGames == null)
            {
                return RedirectToPage("./Index");
            }

            try
            {
                cart.IsCheckedOut = true;
                _context.Carts.Update(cart);

                foreach (var item in cartGames)
                {
                    await _context.AddAsync(new UserGame
                    {
                        GameId = item.Game.Id,
                        UserId = user.Id
                    });
                }

                await _context.SaveChangesAsync();

                return RedirectToPage("./Confirmation", new { cartId = cart.Id });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostFreeAsync()
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

            var cartGames = _context.CartGames.Include(x => x.Game).Where(x => x.CartId == cart.Id);
            if (cartGames == null)
            {
                return RedirectToPage("./Index");
            }

            foreach (var game in cartGames)
            {
                if (game.Price != 0)
                {
                    return RedirectToPage("./Index");
                }
            }

            try
            {
                cart.IsCheckedOut = true;
                _context.Carts.Update(cart);

                foreach (var item in cartGames)
                {
                    await _context.AddAsync(new UserGame
                    {
                        GameId = item.Game.Id,
                        UserId = user.Id
                    });
                }

                await _context.SaveChangesAsync();

                return RedirectToPage("./Confirmation", new { cartId = cart.Id });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }
    }
}