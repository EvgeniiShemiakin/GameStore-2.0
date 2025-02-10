namespace GameStore_2._0.Models
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public List<OrderVM> Orders { get; set; }
        public decimal BuySum { get; set; }
        public int Discount { get; set; }
        public string Role { get; set; }


    }
}
