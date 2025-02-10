using GameStore_2._0.Mappers;

namespace GameStore_2._0.Models.Reps
{
    public class DBGamesRepository : IGamesRepository
    {
        private readonly GameStoreDbContext dataBaseContext;

        public DBGamesRepository(GameStoreDbContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(GameVM gameVM)
        {
            var game = MappingGame.MapToDB(gameVM);
            dataBaseContext.Games.Add(game);
            dataBaseContext.SaveChanges();
        }

        public IEnumerable<GameVM> GetAll()
        { 
            var games = dataBaseContext.Games;
            return games.Select(x => MappingGame.MapToVM(x));
        }
        public IEnumerable<GameVM> GetByGenre(Genre genre)
        {
            var games = dataBaseContext.Games.Where(g => g.Genres != null && g.Genres.Contains((int)genre));
            return games.Select(x => MappingGame.MapToVM(x));
        }
        public GameVM GetById(int id) 
        {
            var game = dataBaseContext.Games.FirstOrDefault(g => g.Id == id);
            return MappingGame.MapToVM(game);
        }
        public void Modify(GameVM updatedGame)
        {
            var game = dataBaseContext.Games.FirstOrDefault(g => g.Id == updatedGame.Id);
            if (game != null)
            {
                game.Title = updatedGame.Title;
                game.Price = updatedGame.Price;
                game.Description = updatedGame.Description;
                game.Genres = updatedGame.Genres?.Select(x => (int)x).ToList() ?? new List<int>();
                game.CrslImg = updatedGame.CrslImg;
                game.CoverImg = updatedGame.CoverImg;
                game.Scr_Thumb = updatedGame.Scr_Thumb;
                game.Trailer = updatedGame.Trailer;
                game.Trailer_Thumb = updatedGame.Trailer_Thumb;
                game.ScreenImg = updatedGame.ScreenImg;
                dataBaseContext.SaveChanges();
            }
        }

        public void Remove(int gameId)
        {
            var gameToRemove = dataBaseContext.Games.FirstOrDefault(g => g.Id == gameId);
            if (gameToRemove != null)
            {
                dataBaseContext.Games.Remove(gameToRemove);
                dataBaseContext.SaveChanges();
            }
        }

        public IEnumerable<GameVM> Search(string searchQuery)
        {
            var games = dataBaseContext.Games.Where(g => g.Title.ToLower().Contains(searchQuery.ToLower())).ToList();
            return games.Select(x => MappingGame.MapToVM(x));
        }

        public void ClickCountIncrement(int id)
        {
            var game = dataBaseContext.Games.FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                game.ClickCount++;
                dataBaseContext.SaveChanges();
            }
        }
    }
}