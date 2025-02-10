using GameStore_2._0.DBModels;
using GameStore_2._0.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameStore_2._0.Models.Reps
{
    public class DBCartsRepository : ICartsRepository
    {
        private readonly GameStoreDbContext dataBaseContext;
        private readonly UserManager<User> userManager;

        public DBCartsRepository(GameStoreDbContext dataBaseContext, UserManager<User> userManager)
        {
            this.dataBaseContext = dataBaseContext;
            this.userManager = userManager;
        }

        public void AddToCart(int gameId, string userId)
        {
            var cart = dataBaseContext.Carts.Include(c => c.Positions).ThenInclude(p => p.Game).FirstOrDefault(c => c.UserId == userId);
            var game = dataBaseContext.Games.FirstOrDefault(g => g.Id == gameId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    Positions = new List<CartPosition>
                    {
                        new CartPosition
                        {
                            Game = game,
                            Amount = 1
                        }
                    }
                };
                dataBaseContext.Carts.Add(cart);
            }
            else
            {
                var position = cart.Positions.FirstOrDefault(p => p.Game.Id == game.Id);
                if (position == null)
                {
                    cart.Positions.Add(new CartPosition
                    {
                        Game = game,
                        Amount = 1
                    });
                }
                else
                {
                    position.Amount++;
                }
            }

            dataBaseContext.SaveChanges();
        }

        public void RemoveFromCart(GameVM game, string userId)
        {
            var cart = dataBaseContext.Carts.Include(c => c.Positions).ThenInclude(p => p.Game).FirstOrDefault(c => c.UserId == userId);

            if (cart != null)
            {
                var position = cart.Positions.FirstOrDefault(p => p.Game.Id == game.Id);
                if (position != null)
                {
                    if (position.Amount > 1)
                    {
                        position.Amount--;
                    }
                    else
                    {
                        cart.Positions.Remove(position);
                    }
                }

                dataBaseContext.SaveChanges();
            }
        }

        public void ClearCart(string userId)
        {
            var cart = dataBaseContext.Carts.Include(c => c.Positions).FirstOrDefault(c => c.UserId == userId);

            if (cart != null)
            {
                cart.Positions.Clear();
                dataBaseContext.SaveChanges();
            }
        }

        public CartVM GetByUserId(string userId)
        {
            var cart = dataBaseContext.Carts.Include(c => c.Positions).ThenInclude(p => p.Game).AsNoTracking().FirstOrDefault(c => c.UserId == userId);
			var cartVM = MappingCart.MapToVM(cart);
			if (cartVM != null)
            {
				cartVM.UserDiscount = userManager.FindByIdAsync(userId).Result.Discount;
			}
			return cartVM;
        }

    }

}
