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
    public class IndexModel : PageModel
    {
        private readonly GameStore.Data.ApplicationDbContext _context;

        public IndexModel(GameStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserGame> UserGame { get;set; }

        public int CountUserGames { get; set; }

        public async Task OnGetAsync()
        {

            CountUserGames = _context.UserGames.Count();

            UserGame = await _context.UserGames
                .Include(u => u.Game)
                .Include(u => u.User).ToListAsync();
        }
    }
}
