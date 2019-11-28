﻿using System;
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
using Microsoft.AspNetCore.Authorization;
using GameStore.Data.Queries;

namespace GameStore.Web.Pages.Wishlist
{
    [Authorize]
    public class WishlistModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public IList<Game> Games { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public WishlistModel(TurboGamesContext context, UserManager<User> userManager)
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

            var games = from uwu in _context.Wishlists
                        where uwu.UserId == user.Id
                        select uwu.Game;

            if (games == null)
            {
                return Page();
            }

            if (!string.IsNullOrEmpty(Search))
            {
                games = games.Where(x => x.Title.Contains(Search.Trim()));
            }

            Games = await games.ToListAsync();

            foreach (var game in Games)
            {
                game.Rating = await _context.GetTotalGameRatingAsync(game);
            }

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
                return RedirectToPage("/Games/Wishlist/Index");
            }

            var game = await _context.Games
                .Include(g => g.Category)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return RedirectToPage("/Games/Library/Index");
            }

            var gameData = new Dictionary<string, string>();
            var gameDataProps = typeof(Game).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));

            foreach (var p in gameDataProps)
            {
                gameData.Add(p.Name, p.GetValue(game)?.ToString() ?? "null");
            }

            Response.Headers.Add("Content-Disposition", $"attachment; filename={game.Title}.json");
            return new FileContentResult(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(gameData)), "text/json");
        }
    }
}
