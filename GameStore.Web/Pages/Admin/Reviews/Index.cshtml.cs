using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace GameStore.Web.Pages.Admin.Games
{
    [Authorize(Roles = "Admin")]
    public class PendingReviewsModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        [TempData]
        public string StatusMessage { get; set; }

        public IList<Review> Review { get; set; }

        public PendingReviewsModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            Review = await _context.Reviews
                .Include(r => r.Game)
                .Include(r => r.Reviewer)
                .Where(r => r.ReviewStatus == ReviewStatus.Pending).ToListAsync();
        }

        public async Task<IActionResult> OnGetAcceptAsync(Guid reviewId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == reviewId);
            if (review == null)
            {
                StatusMessage = $"Error: Unable to find review.";
                return RedirectToPage();
            }

            if (review.ReviewStatus == ReviewStatus.Accepted)
            {
                StatusMessage = $"Error: You have already accepted the '{_context.Reviews.Include(x => x.Game).FirstOrDefault(x => x.Id == reviewId).Game.Title}' review.";
                return RedirectToPage();
            }

            try
            {
                review.ReviewStatus = ReviewStatus.Accepted;
                _context.Update(review);

                await _context.SaveChangesAsync();

                StatusMessage = $"You have accepted the '{_context.Reviews.Include(x => x.Game).FirstOrDefault(x => x.Id == reviewId).Game.Title}' review.";
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
