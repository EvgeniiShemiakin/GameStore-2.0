using GameStore_2._0.Models;
using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using GameStore_2._0.DBModels;

namespace GameStore_2._0.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICartsRepository _cartsRepository;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrdersRepository ordersRepository, ICartsRepository cartsRepository, UserManager<User> userManager)
        {
            _ordersRepository = ordersRepository;
            _cartsRepository = cartsRepository;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var cart = _cartsRepository.GetByUserId(user.Id);
            if (cart == null || !cart.Positions.Any())
            {
                return RedirectToPage("/Error", new { errorMessage = "Корзина пуста." });
            }

            var order = new OrderVM(cart, User.FindFirst(ClaimTypes.Email).Value, _userManager.GetUserAsync(User).Result.PhoneNumber, user.Id, cart.CartCost);
            user.BuySum += cart.CartCost;
            _ordersRepository.Add(order);


            _cartsRepository.ClearCart(user.Id);
            return View();
        }
        public IActionResult GetOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _ordersRepository.GetByUserId(userId);
            return View(orders);
        }
    }
}
