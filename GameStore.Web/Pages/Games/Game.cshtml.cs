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

        public List<Review> Reviews { get; set; }

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

            Game = await _context.GetGameAsync(Id);
            if (Game == null)
            {
                return NotFound();
            }

            Game.Rating = await _context.GetTotalGameRatingAsync(Game);
            CanReviewGame = await _context.DoesUserOwnGameAsync(user, Game);

            Reviews = await _context.GetGameReviewsAsync(Game, true);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Game = await _context.GetGameAsync(Id);
            if (Game == null)
            {
                return NotFound();
            }

            if (await _context.DoesUserOwnGameAsync(user, Game))
            {
                StatusMessage = $"Error: You already own this game.";
                return RedirectToPage();
            }

            var cart = await _context.GetCartAsync(user);
            if (cart == null)
            {
                StatusMessage = $"Error: An error occurred while getting your cart.";
                return RedirectToPage();
            }

            if (await _context.DoesGameExistInCartAsync(cart, Game))
            {
                StatusMessage = $"Error: This game is already in your cart.";
                return RedirectToPage();
            }

            if (await _context.AddToCartAsync(cart, Game))
            {
                StatusMessage = $"'{Game.Title}' has been added to your cart.";
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