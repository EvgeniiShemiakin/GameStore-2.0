namespace GameStore_2._0.Models
{
    public class OrderPositionVM
    {
        public Guid Id { get; set; }
        public GameVM Game { get; set; }
        public int Amount { get; set; }
        public decimal PositionCost
        {
            get
            {
                return Game.Price * Amount;
            }
        }
    }
}
