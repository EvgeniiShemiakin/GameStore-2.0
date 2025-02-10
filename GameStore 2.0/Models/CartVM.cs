namespace GameStore_2._0.Models
{
    public class CartVM
    {
        public Guid Id { get; set; }
        public List<CartPositionVM> Positions { get; set; }
        public string UserId { get; set; }
        public int UserDiscount { get; set; }
        public decimal CartCost
        {
            get
            {
                return Positions.Sum(p => (p.PositionCost - (p.PositionCost / 100 * UserDiscount)));
            }
        }
    }
}
