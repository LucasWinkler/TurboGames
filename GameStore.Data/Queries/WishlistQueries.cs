using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Queries
{
    /// <summary>
    /// TurboGamesContext extension class for common wishlist queries.
    /// </summary>
    public static class WishlistQueries
    {

        /// <summary>
        /// Returns a wishlist by user. If no wishlist exists then a new one will be created.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<Wishlist> GetWishlistAsync(this TurboGamesContext context,
            User user)
        {
            var wishlist = await context.Wishlists.Include(c => c.User).FirstOrDefaultAsync(c => c.User == user && !c.AlreadyExists);
            if (wishlist == null)
            {
                wishlist = new Wishlist { Id = Guid.NewGuid(), UserId = user.Id };

                try
                {
                    await context.Wishlists.AddAsync(wishlist);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException);

                    return await Task.FromResult<Wishlist>(null);
                }
            }
            return wishlist;
        }

        public static async Task<bool> AddToWishlistAsync(this TurboGamesContext context, Wishlist wishlist, Game game)
        {
            try
            {
                await context.WishlistGames.AddAsync(new WishlistGame { WishlistId = wishlist.Id, GameId = game.Id });
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.InnerException);

                return false;
            }
        }

        /// Checks if the game exists in the users wishlist.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cart"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static async Task<bool> DoesGameExistInWishlistAsync(this TurboGamesContext context,
            Wishlist wishlist, Game game)
        {
            return await context.WishlistGames
                .AnyAsync(cg => cg.Wishlist == wishlist && cg.Game == game);
        }

        /// <summary>
        /// Checks if the user already owns the game.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static async Task<bool> UserOwnsGameWishlistAsync(this TurboGamesContext context,
            User user, Game game)
        {
            return await context.UserGames
                .AnyAsync(ug => ug.User == user && ug.Game == game);
        }
    }
}
