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

namespace GameStore.Pages.Admin.Games
{
    public class CreateModel : PageModel
    {
        private readonly GameStore.Data.ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(GameStore.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string username)
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");

            var user = string.IsNullOrEmpty(username)
                ? await _userManager.GetUserAsync(User)
    :            await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return RedirectToPage("/Identity/Account/Login");
            }
            if (user.IsAdmin == false)
            {
                return RedirectToPage("/Home/Index");
            }

            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Games.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}