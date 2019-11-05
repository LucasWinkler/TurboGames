using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;

namespace GameStore.Pages.Games.Library
{
    public class DetailsModel : PageModel
    {
        private readonly GameStore.Data.ApplicationDbContext _context;

        public DetailsModel(GameStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UserGame UserGame { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserGame = await _context.UserGames
                .Include(u => u.Game)
                .Include(u => u.User).FirstOrDefaultAsync(m => m.UserId == id);

            if (UserGame == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
