using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.Pages.Games.Library
{
    public class IndexModel : PageModel
    {
        private readonly ConestogaVirtualGameStore.Data.ApplicationDbContext _context;

        public IndexModel(ConestogaVirtualGameStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string Filter { get; set; }

        public IList<Game> Game { get;set; }

        // Get the list of games or filters it based on the string input
        public async Task OnGetAsync(string _filter)
        {
            Filter = _filter;

            IQueryable<Game> games = from g in _context.Games
                                             select g;
            if (!string.IsNullOrEmpty(_filter))
            {
                games = games.Where(g => g.Title.Contains(_filter));
            }

            Game = await games.
                AsNoTracking().ToListAsync();
        }
    }
}
