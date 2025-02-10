using GameStore_2._0.Models;
using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Mvc;

namespace GameStore_2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGamesRepository _gameRepository;
        public HomeController(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult Index()
        {
            var games = _gameRepository.GetAll().OrderByDescending(x => x.ClickCount).ThenBy(x => x.Title).Take(5).ToList();
            return View(games);
        }

        public IActionResult List(Genre? genre)
        {
            var games = genre.HasValue ? new GameListVM(_gameRepository.GetByGenre(genre.Value), genre.Value) : new GameListVM(_gameRepository.GetAll(), null);
            return View(games);
        }
    }
}
