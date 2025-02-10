namespace GameStore_2._0.Models.Reps
{
    public interface IWishlistRepository
    {
        WishlistVM GetByUserId(string userId);
        void AddToWishlist(int gameId, string userId);
        void RemoveFromWishlist(GameVM game, string userId);
    }
}
