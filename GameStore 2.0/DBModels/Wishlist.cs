namespace GameStore_2._0.DBModels
{
    public class Wishlist
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<WishlistGame> WishlistGames { get; set; }

    }
}
