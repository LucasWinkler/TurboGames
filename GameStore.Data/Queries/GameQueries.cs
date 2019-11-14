﻿using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Queries
{
    /// <summary>
    /// TurboGamesContext extension class for common game queries.
    /// </summary>
    public static class GameQueries
    {
        /// <summary>
        /// Returns a game by id.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public static async Task<Game> GetGameAsync(this TurboGamesContext context,
            Guid gameId)
        {
            return await context.Games
                .Include(g => g.Platform)
                .Include(g => g.Category)
                .Include(g => g.Reviews)
                .FirstOrDefaultAsync(g => g.Id == gameId);
        }

        public static Task<double> GetTotalGameRating(this TurboGamesContext context,
            Guid gameId)
        {
            var game = context.GetGameAsync(gameId).Result;
            if (game == null)
            {
                return Task.FromResult(0d);
            }

            foreach (var review in context.Reviews.Include(x => x.Game)
                .Where(x => x.GameId == game.Id))
            {
                game.Rating += review.Rating;
            }

            return Task.FromResult(game.Rating);
        }

        public static Task<double> GetTotalGameRating(this TurboGamesContext context,
            Game game)
        {
            if (game == null)
            {
                return Task.FromResult(0d);
            }

            foreach (var review in context.Reviews.Include(x => x.Game)
                .Where(x => x.GameId == game.Id))
            {
                game.Rating += review.Rating;
            }

            return Task.FromResult(game.Rating);
        }

        /// <summary>
        /// Returns a cart by user. If no cart exists then a new one will be created.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<ShoppingCart> GetCartAsync(this TurboGamesContext context,
            User user)
        {
            var cart = await context.Carts.Include(c => c.User).FirstOrDefaultAsync(c => c.User == user && !c.IsCheckedOut);
            if (cart == null)
            {
                cart = new ShoppingCart { Id = Guid.NewGuid(), UserId = user.Id };

                try
                {
                    await context.Carts.AddAsync(cart);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException);

                    return await Task.FromResult<ShoppingCart>(null);
                }
            }
            return cart;
        }

        /// <summary>
        /// Attempts to add a game to the cart by cart and game.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cart"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static async Task<bool> AddToCartAsync(this TurboGamesContext context,
            ShoppingCart cart, Game game)
        {
            try
            {
                await context.CartGames.AddAsync(new ShoppingCartGame { CartId = cart.Id, GameId = game.Id });
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);

                return false;
            }
        }

        /// <summary>
        /// Checks if the game exists in the users cart.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cart"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static async Task<bool> DoesGameExistInCartAsync(this TurboGamesContext context,
            ShoppingCart cart, Game game)
        {
            return await context.CartGames
                .AnyAsync(cg => cg.Cart == cart && cg.Game == game);
        }

        /// <summary>
        /// Checks if the user already owns the game.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static async Task<bool> DoesUserOwnGameAsync(this TurboGamesContext context,
            User user, Game game)
        {
            return await context.UserGames
                .AnyAsync(ug => ug.User == user && ug.Game == game);
        }
    }
}
