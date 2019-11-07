using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace GameStore.Pages.Games.Library
{
    public class ReviewModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

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

        public ReviewModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

            Input = new InputModel
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
                StatusMessage = $"Error: Unable to review the '{_context.Game.FirstOrDefault(x => x.Id == Input.GameId).Title}' game.";
                return Page();
            }

            var review = new Review
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

                StatusMessage = $"You have reviewed the '{_context.Game.FirstOrDefault(x => x.Id == review.GameId).Title}' game.";
                return RedirectToPage("./Index", new { statusMessage = StatusMessage });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);
            }

            ViewData["GameTitle"] = review.Game.Title;
            StatusMessage = $"Error: An unknown error has occured.";
            return Page();
        }
    }
}