using GameStore_2._0.DBModels;
using GameStore_2._0.Models;

namespace GameStore_2._0.Mappers
{
    public class MappingPosition
    {
        //public static CartPosition CartPositionVMToCartPosition(CartPositionVM cartPositionVM)
        //{
        //    return new CartPosition
        //    {
        //        Id = cartPositionVM.Id,
        //        Game = MappingGame.MapToDB(cartPositionVM.Game),
        //        Amount = cartPositionVM.Amount
        //    };
        //}
        //public static CartPositionVM CartPositionToCartPositionVM(CartPosition cartPosition)
        //{
        //    return new CartPositionVM
        //    {
        //        Id = cartPosition.Id,
        //        Game = MappingGame.MapToVM(cartPosition.Game),
        //        Amount = cartPosition.Amount
        //    };
        //}
        //public static OrderPosition OrderPositionVMToOrderPosition(OrderPositionVM orderPositionVM)
        //{
        //    return new OrderPosition
        //    {
        //        Id = orderPositionVM.Id,
        //        Game = MappingGame.MapToDB(orderPositionVM.Game),
        //        Amount = orderPositionVM.Amount
        //    };
        //}
        public static OrderPositionVM OrderPositionToOrderPositionVM(OrderPosition orderPosition)
        {
            return new OrderPositionVM
            {
                Id = orderPosition.Id,
                Game = MappingGame.MapToVM(orderPosition.Game),
                Amount = orderPosition.Amount
            };
        }
        //public static CartPosition OrderPositionToCartPosition(OrderPosition orderPosition)
        //{
        //    return new CartPosition
        //    {
        //        Id = orderPosition.Id,
        //        Game = orderPosition.Game,
        //        Amount = orderPosition.Amount
        //    };
        //}
        //public static OrderPosition CartPositionToOrderPosition(CartPosition cartPosition)
        //{
        //    return new OrderPosition
        //    {
        //        Id = cartPosition.Id,
        //        Game = cartPosition.Game,
        //        Amount = cartPosition.Amount
        //    };
        //}
        public static OrderPositionVM CartPositionVMToOrderPositionVM(CartPositionVM cartPositionVM)
        {
            return new OrderPositionVM
            {
                Id = cartPositionVM.Id,
                Game = cartPositionVM.Game,
                Amount = cartPositionVM.Amount
            };
        }   
    }
}
