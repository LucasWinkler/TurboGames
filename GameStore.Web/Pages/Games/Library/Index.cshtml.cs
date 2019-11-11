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
using System.Text;
using Newtonsoft.Json;

namespace GameStore.Web.Pages.Games.Library
{
    public class IndexModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        public Game Game { get; set; }
        public IList<UserGame> UserGame { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public bool IsReviewed { get; set; }

        public IndexModel(TurboGamesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string statusMessage)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            UserGame = await _context.UserGame
                .Include(u => u.Game)
                .Include(u => u.User)
                .Where(u => u.UserId == user.Id)
                .ToListAsync();

            StatusMessage = !string.IsNullOrEmpty(statusMessage) ? statusMessage : "";

            return Page();
        }

        public async Task<IActionResult> OnGetDownloadAsync(Guid? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game
                .Include(g => g.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }

            var gameData = new Dictionary<string, string>();
            var gameDataProps = typeof(Game).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));

            foreach (var p in gameDataProps)
            {
                gameData.Add(p.Name, p.GetValue(Game)?.ToString() ?? "null");
            }

            Response.Headers.Add("Content-Disposition", $"attachment; filename={Game.Title}.json");
            return new FileContentResult(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(gameData)), "text/json");
        }
    }
}
