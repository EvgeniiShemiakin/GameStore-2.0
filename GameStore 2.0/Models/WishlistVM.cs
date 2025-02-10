namespace GameStore_2._0.Models
{
    public class WishlistVM
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<WishlistGameVM> WishlistGames { get; set; }

    }
}
