namespace GameStore_2._0.DBModels
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CartPosition> Positions { get; set; }

    }
}
