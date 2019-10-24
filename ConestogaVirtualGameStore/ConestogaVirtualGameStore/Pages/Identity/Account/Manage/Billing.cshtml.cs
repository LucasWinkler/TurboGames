using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Helpers;
using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConestogaVirtualGameStore.Pages.Identity.Account.Manage
{
    public class BillingModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public BillingModel(
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
        public Payment Payment { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.AddressId != null)
            {
                var address = await _context.Addresses.SingleOrDefaultAsync(x => x.Id == user.AddressId);

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
            
            if (user.PaymentId != null)
            {
                var payment = await _context.Payments.SingleOrDefaultAsync(x => x.Id == user.PaymentId);

                Payment = new Payment
                {
                    CardName = payment.CardName,
                    CardNumber = payment.CardNumber,
                    CardExpirationDate = payment.CardExpirationDate,
                    CardCVC = payment.CardCVC
                };
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Unable to save.");
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            try
            {
                var address = new Address
                {
                    PrimaryAddress = Address.PrimaryAddress,
                    SecondaryAddress = Address.SecondaryAddress,
                    City = Address.City,
                    Country = Address.Country,
                    Province = Address.Province,
                    PostalCode = Address.PostalCode
                };
                _context.Addresses.Add(address);

                var payment = new Payment
                {
                    CardName = Payment.CardName,
                    CardNumber = Payment.CardNumber,
                    CardExpirationDate = Payment.CardExpirationDate,
                    CardCVC = Payment.CardCVC
                };
                _context.Payments.Add(payment);

                user.AddressId = address.Id;
                user.PaymentId = payment.Id;

                await _context.SaveChangesAsync();
                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);

                StatusMessage = "Your account has been updated";
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
