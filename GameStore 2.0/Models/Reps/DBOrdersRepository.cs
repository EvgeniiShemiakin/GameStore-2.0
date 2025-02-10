using GameStore_2._0.DBModels;
using GameStore_2._0.Mappers;
using Microsoft.EntityFrameworkCore;


namespace GameStore_2._0.Models.Reps
{
    public class DBOrdersRepository : IOrdersRepository
    {
        private readonly GameStoreDbContext dataBaseContext;

        public DBOrdersRepository(GameStoreDbContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public void Add(OrderVM orderVM)
        {
            var ids = orderVM.OrderPositions.Select(x => x.Game.Id).ToList();
            var games = dataBaseContext.Games.Where(x => ids.Contains(x.Id)).ToList();
            var order = new Order
            {
                UserId = orderVM.UserId,
                Email = orderVM.Email,
                Phone = orderVM.Phone,
                Date = orderVM.Date,
                OrderPositions = orderVM.OrderPositions.Select(x => new OrderPosition
                {
                    Game = games.FirstOrDefault(game => game.Id == x.Game.Id),
                    Amount = x.Amount
                }).ToList(),
                ActivationKeys = MappingOrder.SerializeToString(orderVM.ActivationKeys),
                OrderCost = orderVM.OrderCost
            };
            dataBaseContext.Orders.Add(order);
            dataBaseContext.SaveChanges();
        }

        public List<OrderVM> GetAll()
        {
            var orders = dataBaseContext.Orders.Include(x => x.OrderPositions).ThenInclude(x => x.Game).ToList();
            if (orders == null)
            {
                return null;
            }
            var ordersVM = orders.Select(order => new OrderVM
            {
                Id = order.Id,
                UserId = order.UserId,
                Email = order.Email,
                Phone = order.Phone,
                Date = order.Date,
                OrderPositions = order.OrderPositions.Select(x => MappingPosition.OrderPositionToOrderPositionVM(x)).ToList(),
                ActivationKeys = (MappingOrder.DeserializeToInt(order.ActivationKeys)).ToDictionary(x => x.Key, x => MappingGame.MapToVM(dataBaseContext.Games.FirstOrDefault(game => game.Id == x.Value))),
                OrderCost = order.OrderCost
            }).ToList();
            return ordersVM;
        }

        public OrderVM GetById(Guid id)
        {
            var order = dataBaseContext.Orders.Include(x => x.OrderPositions).ThenInclude(x => x.Game).FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return null;
            }
            return new OrderVM
            {
                Id = order.Id,
                UserId = order.UserId,
                Email = order.Email,
                Phone = order.Phone,
                Date = order.Date,
                OrderPositions = order.OrderPositions.Select(x => MappingPosition.OrderPositionToOrderPositionVM(x)).ToList(),
                ActivationKeys = (MappingOrder.DeserializeToInt(order.ActivationKeys)).ToDictionary(x => x.Key, x => MappingGame.MapToVM(dataBaseContext.Games.FirstOrDefault(game => game.Id == x.Value))),
                OrderCost = order.OrderCost
            };

        }

        public List<OrderVM> GetByUserId(string id)
        {
            var orders = dataBaseContext.Orders.Include(x => x.OrderPositions).ThenInclude(x => x.Game).Where(x => x.UserId == id).ToList();
            if (orders == null)
            {
                return null;
            }
            var ordersVM = orders.Select(order => new OrderVM
            {
                Id = order.Id,
                UserId = order.UserId,
                Email = order.Email,
                Phone = order.Phone,
                Date = order.Date,
                OrderPositions = order.OrderPositions.Select(x => MappingPosition.OrderPositionToOrderPositionVM(x)).ToList(),
                ActivationKeys = (MappingOrder.DeserializeToInt(order.ActivationKeys)).ToDictionary(x => x.Key, x => MappingGame.MapToVM(dataBaseContext.Games.FirstOrDefault(game => game.Id == x.Value))),
                OrderCost = order.OrderCost
            }).ToList();
            return ordersVM;
        }
    }
}
