namespace GameStore_2._0.Models
{
    public class GameListVM
    {
        public IEnumerable<GameVM> Games { get; }
        public Genre? Genre { get; }
        public GameListVM(IEnumerable<GameVM> games, Genre? genre)
        {
            Games = games;
            Genre = genre;
        }
    }
}
