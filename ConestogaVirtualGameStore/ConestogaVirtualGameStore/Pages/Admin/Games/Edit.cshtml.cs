using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity;

namespace ConestogaVirtualGameStore.Pages.Admin.Games
{
    public class EditModel : PageModel
    {
        private readonly ConestogaVirtualGameStore.Data.ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(ConestogaVirtualGameStore.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, string username)
        {
            var user = string.IsNullOrEmpty(username)
                ? await _userManager.GetUserAsync(User)
                : await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return RedirectToPage("/Identity/Account/Login");
            }
            if (user.IsAdmin == false)
            {
                return RedirectToPage("/Home/Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games
                .Include(g => g.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(Game.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameExists(Guid id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
