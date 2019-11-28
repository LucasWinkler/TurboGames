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

        public bool CanReview { get; set; }
        public bool HasReview { get; set; }

        [BindProperty]
        public Review Review { get; set; }

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
            CanReview = await _context.DoesUserOwnGameAsync(user, Game);
            Reviews = await _context.GetGameReviewsAsync(Game);
            Review = Reviews.FirstOrDefault(r => r.Reviewer == user);
            HasReview = Review == null ? false : true;

            return Page();
        }

        public async Task<IActionResult> OnPostCartAsync()
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

            //Cart
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

            var isAddedToCart = _context.AddToCartAsync(cart, Game).IsCompletedSuccessfully;
            if (isAddedToCart)
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

        public async Task<IActionResult> OnPostWishlistAsync()
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

      

            //Wishlist
            var wishlist = await _context.GetWishlistAsync(user);
            if (wishlist == null)
            {
                StatusMessage = $"Error: An error occurred while getting your wishlist.";
                return RedirectToPage();
            }

            if (await _context.DoesGameExistInWishlistAsync(wishlist, Game))
            {
                StatusMessage = $"Error: This game is already on your wishlist.";
                return RedirectToPage();
            }

            if (await _context.AddToWishlistAsync(wishlist, Game))
            {
                StatusMessage = $"'{Game.Title}' has been added to your wishlist.";
                return RedirectToPage();
            }
            else
            {
                StatusMessage = $"Error: We were unable to add that game to your wishlist.";
                return RedirectToPage();
            }

        }

        public async Task<IActionResult> OnPostReviewGameAsync()
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

            CanReview = await _context.DoesUserOwnGameAsync(user, Game);
            Reviews = await _context.GetGameReviewsAsync(Game);

            if (!CanReview)
            {
                StatusMessage = $"Error: You are not able to review this game.";
                return RedirectToPage();
            }

            var review = Reviews.FirstOrDefault(r => r.Reviewer == user);
            HasReview = review == null ? false : true;

            try
            {
                if (HasReview)
                {
                    review.ReviewStatus = ReviewStatus.Pending;
                    review.Content = Review.Content;
                    review.Rating = Review.Rating;

                    _context.Attach(review).State = EntityState.Modified;

                    StatusMessage = $"Review saved and is currently pending. Please wait for an administrator to accept it.";
                }
                else
                {
                    await _context.Reviews.AddAsync(new Review { ReviewerId = user.Id, GameId = Game.Id, Content = Review.Content, Rating = Review.Rating });

                    StatusMessage = $"Review posted and is currently pending. Please wait for an administrator to accept it.";
                }

                await _context.SaveChangesAsync();

                return RedirectToPage();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.Id))
                {
                    StatusMessage = $"Error: An unknown error has occurred while trying to post your review.";
                    return RedirectToPage();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ReviewExists(Guid id)
        {
            return Reviews.Any(r => r.Id == id);
        }
    }
}