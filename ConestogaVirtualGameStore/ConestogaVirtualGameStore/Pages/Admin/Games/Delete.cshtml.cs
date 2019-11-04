using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity;

namespace ConestogaVirtualGameStore.Pages.Admin.Games
{
    public class DeleteModel : PageModel
    {
        private readonly ConestogaVirtualGameStore.Data.ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteModel(ConestogaVirtualGameStore.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games.FindAsync(id);

            if (Game != null)
            {
                _context.Games.Remove(Game);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
