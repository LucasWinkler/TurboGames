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

namespace GameStore.Pages.Admin.Games
{
    public class IndexModel : PageModel
    {
        private readonly GameStore.Data.ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(GameStore.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Game> Game { get;set; }

        public async Task<IActionResult> OnGetAsync(string username)
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

            Game = await _context.Games
                .Include(g => g.Category).ToListAsync();

            return Page();
        }
    }
}
