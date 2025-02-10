using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameStore_2._0.Components
{
    public class WishlistItems : ViewComponent
    {
        private readonly IWishlistRepository _wishlistRepository;
        public WishlistItems(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }
        public IViewComponentResult Invoke()
        {
            var userId = UserClaimsPrincipal?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return View(0); // Если пользователь не авторизован, корзина пустая
            }
            var wishlist = _wishlistRepository.GetByUserId(userId);
            return View(wishlist?.WishlistGames?.Count() ?? 0);

        }
    }
}
