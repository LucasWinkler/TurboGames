using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Cart
{
    [Authorize]
    public class ConfirmationModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        public ConfirmationModel(UserManager<User> userManager, TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid cartId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (cartId == null)
            {
                return RedirectToPage("./Index");
            }

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null)
            {
                return RedirectToPage("./Index");
            }

            if (cart.User != user)
            {
                return RedirectToPage("/Account/AccessDenied");
            }

            return Page();
        }
    }
}