using GameStore_2._0.DBModels;
using GameStore_2._0.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GameStore_2._0.Models.Reps
{
    public class DBWishlistRepository : IWishlistRepository
    {
        private readonly GameStoreDbContext dataBaseContext;

        public DBWishlistRepository(GameStoreDbContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public void AddToWishlist(int gameId, string userId)
        {
            var wishlist = dataBaseContext.Wishlists.Include(w => w.WishlistGames).ThenInclude(wg => wg.Game).FirstOrDefault(w => w.UserId == userId);
            var game = dataBaseContext.Games.FirstOrDefault(g => g.Id == gameId);

            if (wishlist == null)
            {
                wishlist = new Wishlist
                {
                    UserId = userId,
                    WishlistGames = new List<WishlistGame>
                    {
                            new WishlistGame
                            {
                                Game = game
                            }
                    }
                };
                dataBaseContext.Wishlists.Add(wishlist);
            }
            else
            {
                var wishlistGame = wishlist.WishlistGames.FirstOrDefault(wg => wg.Game.Id == game.Id);
                if (wishlistGame == null)
                {
                    var newWishlistGame = new WishlistGame
                    {
                        Game = game
                    };
                    wishlist.WishlistGames.Add(newWishlistGame);
                }
            }
            dataBaseContext.SaveChanges();
        }

        public WishlistVM GetByUserId(string userId)
        {
            var wishlist = dataBaseContext.Wishlists.Include(x => x.WishlistGames).ThenInclude(x => x.Game).FirstOrDefault(w => w.UserId == userId);

            return wishlist == null ? new WishlistVM
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    WishlistGames = new List<WishlistGameVM>()
                } : MappingWishlist.MapToVM(wishlist);
        }
        public void RemoveFromWishlist(GameVM game, string userId)
        {
            var wishlist = dataBaseContext.Wishlists.Include(x => x.WishlistGames).ThenInclude(x => x.Game).FirstOrDefault(w => w.UserId == userId);
            if (wishlist != null)
            {
                var wishlistGame = wishlist.WishlistGames.FirstOrDefault(wg => wg.Game.Id == game.Id);
                if (wishlistGame != null)
                {
                    wishlist.WishlistGames.Remove(wishlistGame);
                    dataBaseContext.SaveChanges();
                }
            }
        }
    }
}
