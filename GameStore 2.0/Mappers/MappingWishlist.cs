using GameStore_2._0.Models;
using GameStore_2._0.DBModels;

namespace GameStore_2._0.Mappers
{
    public class MappingWishlist
    {
        public static Wishlist MapToDB(WishlistVM wishlistVM)
        {
            return new Wishlist
            {
                Id = wishlistVM.Id,
                UserId = wishlistVM.UserId,
                WishlistGames = wishlistVM.WishlistGames?.Select(wg => new WishlistGame
                {
                    Game = MappingGame.MapToDB(wg.Game),
                    DateAdded = wg.DateAdded
                }).ToList() ?? new List<WishlistGame>()
            };
        }

        public static WishlistVM MapToVM(Wishlist wishlist)
        {
            return new WishlistVM
            {
                Id = wishlist.Id,
                UserId = wishlist.UserId,
                WishlistGames = wishlist.WishlistGames?.Select(wg => new WishlistGameVM
                {
                    Game = MappingGame.MapToVM(wg.Game),
                    DateAdded = wg.DateAdded
                }).ToList() ?? new List<WishlistGameVM>()
            };
        }
    }
}
