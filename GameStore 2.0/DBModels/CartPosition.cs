namespace GameStore_2._0.DBModels
{
    public class CartPosition
    {
        public Guid Id { get; set; }
        public Game Game { get; set; }
        public int Amount { get; set; }
        public Cart Cart { get; set; }
    }
}
