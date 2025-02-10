using GameStore_2._0.Mappers;

namespace GameStore_2._0.Models
{
    public class OrderVM
    {
        public Guid Id { get; set; }
        public List<OrderPositionVM> OrderPositions { get; set; } = new List<OrderPositionVM>();
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public decimal OrderCost { get; set; }
        public Dictionary<Guid, GameVM> ActivationKeys { get; set; } //ключ активации : игра
        public OrderVM()
        { 
        }
        public OrderVM(CartVM cart, string email, string phone, string userID, decimal orderCost)
        {
            foreach (var position in cart.Positions)
            {
                OrderPositions.Add(MappingPosition.CartPositionVMToOrderPositionVM(position));
            }
            Email = email;
            Phone = phone;
            UserId = userID;
            Date = DateTime.Now;
            ActivationKeys = GenerateActivationKeys(cart);
            OrderCost = orderCost;
        }
        private Dictionary<Guid, GameVM> GenerateActivationKeys(CartVM cart)
        {
            var keys = new Dictionary<Guid, GameVM>();
            foreach (var game in cart.Positions)
            {
                for (var i = 0; i < game.Amount; i++)
                {
                    keys[Guid.NewGuid()] = game.Game;
                }
            }
            return keys;
        }
    }
}
