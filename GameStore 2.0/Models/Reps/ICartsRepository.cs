using GameStore_2._0.DBModels;

namespace GameStore_2._0.Models.Reps
{
    public interface ICartsRepository
    {
        void AddToCart(int gameId, string userId);
        void RemoveFromCart(GameVM game, string userId);
        void ClearCart(string userId);
        CartVM GetByUserId(string userId);
    }
}
