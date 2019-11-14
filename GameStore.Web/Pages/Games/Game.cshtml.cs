using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data;
using GameStore.Data.Models;
using GameStore.Data.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Pages.Games
{
    [Authorize]
    public class GameModel : PageModel
    {
        private readonly TurboGamesContext _context;
        private readonly UserManager<User> _userManager;

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public Game Game { get; set; }

        public bool CanReviewGame { get; set; }

        public GameModel(
            UserManager<User> userManager,
            TurboGamesContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var game = _context.GetGameAsync(Id).Result;
            if (game == null)
            {
                return NotFound();
            }

            Game = game;
            
            CanReviewGame = await _context.DoesUserOwnGameAsync(user, game);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var game = _context.GetGameAsync(Id).Result;
            if (game == null)
            {
                return NotFound();
            }

            if (_context.DoesUserOwnGameAsync(user, game).Result)
            {
                StatusMessage = $"Error: You already own this game.";
                return RedirectToPage();
            }

            var cart = _context.GetCartAsync(user).Result;
            if (cart == null)
            {
                StatusMessage = $"Error: An error occurred while getting your cart.";
                return RedirectToPage();
            }

            if (_context.DoesGameExistInCartAsync(cart, game).Result)
            {
                StatusMessage = $"Error: This game is already in your cart.";
                return RedirectToPage();
            }

            if (_context.AddToCartAsync(cart, game).Result)
            {
                StatusMessage = $"'{game.Title}' has been added to your cart.";
                return RedirectToPage();
            }
            else
            {
                StatusMessage = $"Error: We were unable to add that game to your cart.";
                return RedirectToPage();
            }
        }
    }
}