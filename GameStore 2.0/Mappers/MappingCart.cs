using GameStore_2._0.Models;
using GameStore_2._0.DBModels;

namespace GameStore_2._0.Mappers
{
    public class MappingCart
    {
        public static CartVM MapToVM(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartVM
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Positions = cart.Positions.Select(p => new CartPositionVM
                {
                    Game = MappingGame.MapToVM(p.Game),
                    Amount = p.Amount,
                }).ToList()
            };
        }
        public static Cart MapToDB (CartVM cartVM)
        {
            if (cartVM == null)
            {
                return null;
            }
            return new Cart
            {
                UserId = cartVM.UserId,
                Positions = cartVM.Positions.Select(p => new CartPosition
                {
                    Game = MappingGame.MapToDB(p.Game),
                    Amount = p.Amount
                }).ToList()
            };
        }
    }
}
