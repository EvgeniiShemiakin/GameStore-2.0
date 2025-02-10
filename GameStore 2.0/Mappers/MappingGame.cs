using GameStore_2._0.Models;
using GameStore_2._0.DBModels;
using Microsoft.EntityFrameworkCore;


namespace GameStore_2._0.Mappers
{
    public class MappingGame
    {
        public static Game MapToDB(GameVM gameVM)
        {
            if (gameVM == null)
            {
                return null;
            }
            return new Game
            {
                Id = gameVM.Id,
                Title = gameVM.Title,
                Price = gameVM.Price,
                Description = gameVM.Description,
                ClickCount = gameVM.ClickCount,
                Genres = gameVM.Genres?.Select(x => (int)x).ToList() ?? new List<int>(),
                CrslImg = gameVM.CrslImg,
                CoverImg = gameVM.CoverImg,
                Scr_Thumb = gameVM.Scr_Thumb,
                Trailer = gameVM.Trailer,
                Trailer_Thumb = gameVM.Trailer_Thumb,
                ScreenImg = gameVM.ScreenImg
            };
        }
        public static GameVM MapToVM(Game game)
        {
            if (game == null)
            {
                return null;
            }
            return new GameVM
            {
                Id = game.Id,
                Title = game.Title,
                Price = game.Price,
                Description = game.Description,
                ClickCount = game.ClickCount,
                Genres = game.Genres?.Select(x => (Genre)x).ToList() ?? new List<Genre>(),
                CrslImg = game.CrslImg,
                CoverImg = game.CoverImg,
                Scr_Thumb = game.Scr_Thumb,
                Trailer = game.Trailer,
                Trailer_Thumb = game.Trailer_Thumb,
                ScreenImg = game.ScreenImg
            };
        }
    }
}