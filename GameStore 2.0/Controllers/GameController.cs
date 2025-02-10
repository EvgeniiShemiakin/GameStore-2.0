using GameStore_2._0.Models;
using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Mvc;

namespace GameStore_2._0.Controllers
{
    public class GameController : Controller
    {
        private readonly IGamesRepository _gameRepository;
        public GameController(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult Index(int id)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
            {
				return RedirectToPage("/Error", new { errorMessage = "Такой игры нет." });
			}
            _gameRepository.ClickCountIncrement(id);
            return View(game);
        }
    }
}
