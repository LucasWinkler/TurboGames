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
using Microsoft.AspNetCore.Authorization;

namespace GameStore.Web.Pages.Admin.Events
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Event> Event { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Event = await _context.Event.ToListAsync();

            return Page();
        }
    }
}
