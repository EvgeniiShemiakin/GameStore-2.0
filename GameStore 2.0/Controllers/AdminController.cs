using GameStore_2._0.DBModels;
using GameStore_2._0.Models;
using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore_2._0.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly UserManager<User> _userManager;

        public AdminController(IGamesRepository gamesRepository, IOrdersRepository ordersRepository, UserManager<User> userManager)
        {
            _gamesRepository = gamesRepository;
            _ordersRepository = ordersRepository;
            _userManager = userManager;
        }
        public IActionResult AllOrders()
        {
            var orders = _ordersRepository.GetAll();
            return View(orders);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllGames()
        {
            var games = _gamesRepository.GetAll().ToList();
            return View(games);
        }
        public IActionResult Remove(int gameId)
        {
            _gamesRepository.Remove(gameId);
            return RedirectToAction("AllGames");
        }
        public IActionResult Modify(int Id)
        {
            var game = _gamesRepository.GetById(Id);
            if (game == null)
            {
                return RedirectToPage("/Error", new { errorMessage = "Такой игры нет." });
            }
            return View(game);
        }
        [HttpPost]
        public IActionResult Modify(GameVM game)
        {
            var existingGame = _gamesRepository.GetById(game.Id);
            existingGame.Title = game.Title;
            existingGame.Price = game.Price;
            existingGame.Description = game.Description;
            existingGame.Genres = game.Genres;
            existingGame.CrslImg = game.CrslImg;
            existingGame.CoverImg = game.CoverImg;
            existingGame.Scr_Thumb = game.Scr_Thumb;
            existingGame.Trailer = game.Trailer;
            existingGame.Trailer_Thumb = game.Trailer_Thumb;
            existingGame.ScreenImg = game.ScreenImg;

            //_gamesRepository.Update(existingGame); // Теперь изменения сохраняются

            return RedirectToAction("AllGames");
        }
        public IActionResult AddGame()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGame(GameVM game, [FromForm] string imgPath, [FromForm] string trailerId)
        {
            game.CoverImg = $"{imgPath}/cover.jpg";
            game.CrslImg = $"{imgPath}/crsl.jpg";
            game.Scr_Thumb = $"{imgPath}/scr_thumb.jpg";
            game.ScreenImg = new List<string> { $"{imgPath}/scr1.jpg", $"{imgPath}/scr2.jpg", $"{imgPath}/scr3.jpg" };
            game.Scr_Thumb = $"{imgPath}/scr1.jpg";
            game.Trailer = $"https://www.youtube.com/embed/{trailerId}";
            game.Trailer_Thumb = $"https://img.youtube.com/vi/{trailerId}/mqdefault.jpg";
            _gamesRepository.Add(game);
            return RedirectToAction("AllGames");
        }
        public IActionResult AboutOrder(Guid id)
        {
            var order = _ordersRepository.GetById(id);
            return View(order);
        }
        public IActionResult AllUsers()
        {
            var userAccounts = _userManager.Users.Select(user => new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                Role = _userManager.GetRolesAsync(user).Result.Contains("Admin") ? "Admin" : "User",
                Phone = user.PhoneNumber,
                BuySum = user.BuySum,
                Discount = user.Discount,
                Orders = _ordersRepository.GetByUserId(user.Id)
            }).ToList();
            return View(userAccounts);
        }
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction("AllUsers");
        }
        public async Task<IActionResult> ChangeRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            return RedirectToAction("AllUsers");
        }
        public async Task<IActionResult> AboutUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var userVM = new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Role = _userManager.GetRolesAsync(user).Result.Contains("Admin") ? "Admin" : "User",
                Discount = user.Discount,
                BuySum = user.BuySum,
                Orders = _ordersRepository.GetByUserId(user.Id)
            };
            return View(userVM);
        }
    }
}
