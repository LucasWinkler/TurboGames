using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Web.Helpers;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;

namespace GameStore.Web.Pages.Account.Settings.Addresses
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly TurboGamesContext _context;

        public IList<UserAddress> Addresses { get; set; }

        public IndexModel(
            UserManager<User> userManager,
            TurboGamesContext context)
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

            Addresses = await _context.UserAddresses
                .Include(x => x.User)
                .Include(x => x.Address)
                .Where(x => x.UserId == user.Id).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveAddressAsync(Guid addressId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);
                var userAddress = await _context.UserAddresses
                    .FirstOrDefaultAsync(x => x.AddressId == addressId && x.UserId == user.Id);

                _context.UserAddresses.Remove(userAddress);

                await _context.SaveChangesAsync();

                _context.Addresses.Remove(address);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }
    }
}
