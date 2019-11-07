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

namespace GameStore.Pages.Games.Store
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public IList<Game> Game { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Game = await _context.Game
                .Include(x => x.Platform)
                .Include(x => x.Category)
                .AsNoTracking().ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAddItemToCartAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCheckedOut);
            if (cart == null)
            {
                try
                {
                    cart = new Models.Cart
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

            var gameToAdd = await _context.Game.FirstOrDefaultAsync(x => x.Id == id);

            var cartGameToAdd = new CartGame
            {
                CartId = cart.Id,
                GameId = gameToAdd.Id,
                Price = gameToAdd.Price
            };

            try
            {
                await _context.AddAsync(cartGameToAdd);

                await _context.SaveChangesAsync();

                return RedirectToPage();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }
    }
}