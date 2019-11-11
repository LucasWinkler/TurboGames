using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace GameStore.Web.Pages.Games.Library
{
    [Authorize]
    public class ReviewModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public bool IsReviewed { get; set; } = false;

        public class InputModel
        {
            [Required]
            public Guid GameId { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            public string Content { get; set; }

            [Required]
            [Range(0, 5)]
            public int Rating { get; set; }
        }

        public ReviewModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var review = await _context.Review.FirstOrDefaultAsync(x => x.GameId == id && x.ReviewerId == user.Id);
            Input = review != null
                ? new InputModel
                {
                    GameId = id,
                    Content = review.Content,
                    Rating = review.Rating
                }
                : new InputModel
                {
                    GameId = id
                };

            ViewData["GameTitle"] = _context.Game.FirstOrDefault(x => x.Id == id).Title;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var review = await _context.Review.FirstOrDefaultAsync(x => x.GameId == Input.GameId && x.ReviewerId == user.Id);
            if (review != null)
            {
                review.Content = Input.Content;
                review.Rating = Input.Rating;

                _context.Update(review);

                try
                {
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index", new { statusMessage = $"You have edited your review for '{_context.Game.FirstOrDefault(x => x.Id == review.GameId).Title}'." });
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException);
                }
            }

            review = new Review
            {
                GameId = Input.GameId,
                ReviewerId = user.Id,
                Content = Input.Content,
                Rating = Input.Rating
            };

            try
            {
                await _context.Review.AddAsync(review);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index", new { statusMessage = $"You have reviewed '{_context.Game.FirstOrDefault(x => x.Id == review.GameId).Title}'." });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            ViewData["GameTitle"] = review.Game.Title;
           
            return Page();
        }
    }
}