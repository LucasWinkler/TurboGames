using System;
using System.Diagnostics;
using System.Linq;
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
        public Address InputAddress { get; set; }

        [BindProperty]
        public Payment InputPayment { get; set; }

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

                InputAddress = new Address
                {
                    PrimaryAddress = address.PrimaryAddress,
                    SecondaryAddress = address.SecondaryAddress,
                    Country = address.Country,
                    Province = address.Province,
                    PostalCode = address.PostalCode
                };
            }
            
            if (user.PaymentId != null)
            {
                var payment = await _context.Payments.SingleOrDefaultAsync(x => x.Id == user.PaymentId);

                InputPayment = new Payment
                {
                    CardName = payment.CardName,
                    CardNumber = payment.CardNumber,
                    CardType = payment.CardType,
                    CardExpirationDate = payment.CardExpirationDate
                };
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
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
                    PrimaryAddress = InputAddress.PrimaryAddress,
                    SecondaryAddress = InputAddress.SecondaryAddress,
                    Country = InputAddress.Country,
                    Province = InputAddress.Province,
                    PostalCode = InputAddress.PostalCode
                };
                _context.Addresses.Add(address);

                var payment = new Payment
                {
                    CardName = InputPayment.CardName,
                    CardType = PaymentHelper.GetType(InputPayment.CardNumber).ToString(),
                    CardNumber = InputPayment.CardNumber,
                    CardExpirationDate = InputPayment.CardExpirationDate
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
