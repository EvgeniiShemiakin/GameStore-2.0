using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameStore_2._0.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IGamesRepository _gameRepository;
        private readonly ICartsRepository _cartRepository;
        public CartController(IGamesRepository gameRepository, ICartsRepository cartRepository)
        {
            _gameRepository = gameRepository;
            _cartRepository = cartRepository;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_cartRepository.GetByUserId(userId));
        }
        public IActionResult AddToCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _cartRepository.AddToCart(id, userId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddToCartAjax(int id)
        { 
            if (User.Identity.IsAuthenticated == false)
            {
                return Json(new { success = false, message = "Вы должны войти в аккаунт." });
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _cartRepository.AddToCart(id, userId);
            return Json(new { success = true });
        }
        public IActionResult RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var game = _gameRepository.GetById(id);
            _cartRepository.RemoveFromCart(game, userId);
            return RedirectToAction("Index");
        }
        public IActionResult ClearCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _cartRepository.ClearCart(userId);
            return RedirectToAction("Index");
        }
    }
}
