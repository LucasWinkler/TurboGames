using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Pages.Account.Settings
{
    public class ShippingAddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public ShippingAddressModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public Address Address { get; set; }

        [BindProperty]
        public bool IsSameAsBilling { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            try
            {
                if (user.ShippingAddressId != user.BillingAddressId)
                {
                    Address = await _context.Address.FirstOrDefaultAsync(x => x.Id == user.ShippingAddressId);
                    IsSameAsBilling = false;
                }
                else
                {
                    Address = await _context.Address.FirstOrDefaultAsync(x => x.Id == user.BillingAddressId);
                    IsSameAsBilling = true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (IsSameAsBilling)
            {
                try
                {
                    user.ShippingAddressId = user.BillingAddressId;

                    await _userManager.UpdateAsync(user);
                    await _signInManager.RefreshSignInAsync(user);

                    StatusMessage = "Your shipping address has been updated";
                    return RedirectToPage();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException);
                }
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Unable to save.");
                    return Page();
                }

                try
                {
                    _context.Address.Add(Address);

                    user.ShippingAddressId = Address.Id;

                    await _context.SaveChangesAsync();

                    await _userManager.UpdateAsync(user);
                    await _signInManager.RefreshSignInAsync(user);

                    StatusMessage = "Your shipping address has been updated";
                    return RedirectToPage();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveAddressAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.ShippingAddressId == null)
            {
                ModelState.AddModelError("", "Unable to remove address.");
                return Page();
            }

            try
            {
                if (user.ShippingAddressId == user.BillingAddressId)
                {
                    user.ShippingAddressId = null;
                }
                else
                {
                    var address = await _context.Address.FirstOrDefaultAsync(x => x.Id == user.ShippingAddressId);
                    // todo stuff

                    _context.Address.Remove(address);
                }

                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
                await _signInManager.RefreshSignInAsync(user);

                IsSameAsBilling = false;

                StatusMessage = "Your billing address has been removed";
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
