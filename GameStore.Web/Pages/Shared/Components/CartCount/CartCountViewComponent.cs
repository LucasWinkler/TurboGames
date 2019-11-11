using GameStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Shared.Components.CartCount
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public CartCountViewComponent(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return View(0);
            }

            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCheckedOut);
            if (cart != null)
            {
                var count = _context.CartGame.Count(x => x.CartId == cart.Id);

                return View(count);
            }

            return View(0);
        }
    }
}
