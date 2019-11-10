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
    public class AddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AddressModel(
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

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.BillingAddressId != null)
            {
                var address = await _context.Address.FirstOrDefaultAsync(x => x.Id == user.BillingAddressId);

                Address = new Address
                {
                    PrimaryAddress = address.PrimaryAddress,
                    SecondaryAddress = address.SecondaryAddress,
                    City = address.City,
                    Country = address.Country,
                    Province = address.Province,
                    PostalCode = address.PostalCode
                };
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

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Unable to save.");
                return Page();
            }

            try
            {
                _context.Address.Add(Address);

                user.BillingAddressId = Address.Id;

                await _context.SaveChangesAsync();

                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);

                StatusMessage = "Your billing address has been updated";
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
