namespace GameStore_2._0.DBModels
{
    public class OrderPosition
    {
        public Guid Id { get; set; }
        public Game Game { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
    }
}
