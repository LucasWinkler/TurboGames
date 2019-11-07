using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameStore.Data;
using GameStore.Models;

namespace GameStore.Pages.Games.Library
{
    public class ReviewModel : PageModel
    {
        private readonly GameStore.Data.ApplicationDbContext _context;

        public ReviewModel(GameStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string title)
        {
            ViewData["GameTitle"] = title;
            ViewData["ReviewerId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}