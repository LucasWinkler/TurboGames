using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Helpers;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Pages.Identity.Account.Manage
{
    public class PaymentModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public PaymentModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

      
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
                var payment = new Payment
                {
                    CardName = Payment.CardName,
                    CardNumber = Payment.CardNumber,
                    CardExpirationDate = Payment.CardExpirationDate,
                    CardCVC = Payment.CardCVC
                };

                _context.Payments.Add(payment);

                user.PaymentId = payment.Id;

                await _context.SaveChangesAsync();
                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);

                StatusMessage = "Your payment information has been updated";
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
