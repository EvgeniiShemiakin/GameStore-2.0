namespace GameStore_2._0.DBModels
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderPosition> OrderPositions { get; set; }
        public string UserId { get; set; }
        public User User { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string ActivationKeys { get; set; }
        public decimal OrderCost { get;set; }
    }
}
