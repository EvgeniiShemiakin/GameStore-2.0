namespace GameStore_2._0.Models.Reps
{
    public interface IGamesRepository
    {
        IEnumerable<GameVM> GetAll();
        IEnumerable<GameVM> GetByGenre(Genre genre);
        GameVM GetById(int id);
        IEnumerable<GameVM> Search(string searchQuery);
        void Remove(int gameId);
        void Modify(GameVM updatedGame);
        void Add(GameVM game);
        void ClickCountIncrement(int id);
    }
}
