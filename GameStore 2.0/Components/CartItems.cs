using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameStore_2._0.Components
{
    public class CartItems : ViewComponent
    {
        private readonly ICartsRepository _cartRepository;
        public CartItems(ICartsRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public IViewComponentResult Invoke()
        {
            var userId = UserClaimsPrincipal?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return View(0);
            }

            var cart = _cartRepository.GetByUserId(userId);
            return View(cart?.Positions?.Sum(position => position.Amount) ?? 0);
        }
    }
}
