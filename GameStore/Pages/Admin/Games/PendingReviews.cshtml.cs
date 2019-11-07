using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace GameStore.Pages.Admin.Games
{
    public class PendingReviewsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        [TempData]
        public string StatusMessage { get; set; }

        public IList<Review> Review { get; set; }

        public PendingReviewsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            Review = await _context.Review
                .Include(r => r.Game)
                .Include(r => r.Reviewer)
                .Where(x => !x.IsAccepted).ToListAsync();
        }

        public async Task<IActionResult> OnGetAcceptAsync(Guid reviewId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var review = await _context.Review.FirstOrDefaultAsync(x => x.Id == reviewId);
            if (review == null)
            {
                StatusMessage = $"Error: Unable to find review.";
                return RedirectToPage();
            }

            if (review.IsAccepted)
            {
                StatusMessage = $"Error: You have already accepted the '{_context.Review.Include(x => x.Game).FirstOrDefault(x => x.Id == reviewId).Game.Title}' review.";
                return RedirectToPage();
            }

            review.IsAccepted = true;

            try
            {
                _context.Update(review);
                await _context.SaveChangesAsync();

                StatusMessage = $"You have accepted the '{_context.Review.Include(x => x.Game).FirstOrDefault(x => x.Id == reviewId).Game.Title}' review.";
                return RedirectToPage();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            return RedirectToPage();
        }
    }
}
