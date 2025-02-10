namespace GameStore_2._0.DBModels
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ClickCount { get; set; } = 0;
        public List<int>? Genres { get; set; }
        public string? CrslImg { get; set; }
        public string? CoverImg { get; set; }
        public string? Scr_Thumb { get; set; }
        public string? Trailer { get; set; }
        public string? Trailer_Thumb { get; set; }
        public List<string>? ScreenImg { get; set; }
        public List<CartPosition> CartPositions { get; set; }
        public List<WishlistGame> WishlistGames { get; set; }
    }
}