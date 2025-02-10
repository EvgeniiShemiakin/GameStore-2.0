using GameStore_2._0.Models;
using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace GameStore_2._0.Pages
{
    [Authorize]
    public class WishlistModel : PageModel
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IWishlistRepository _wishlistRepository;
        public WishlistVM Wishlist { get; set; }

        public WishlistModel(IGamesRepository gamesRepository, IWishlistRepository wishlistRepository)
        {
            _gamesRepository = gamesRepository;
            _wishlistRepository = wishlistRepository;
        }

        public IActionResult OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToPage("/Error", new { errorMessage = "Пользователь не найден." });
            }

            Wishlist = _wishlistRepository.GetByUserId(userId);
            return Page();
        }
        public IActionResult OnGetAddToWishlist(int gameId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToPage("/Error", new { errorMessage = "Пользователь не найден." });
            }

            var game = _gamesRepository.GetById(gameId);
            if (game == null)
            {
                return RedirectToPage("/Error", new { errorMessage = "Нет игры с таким ID." });
            }

            _wishlistRepository.AddToWishlist(gameId, userId);
            return RedirectToPage("/Wishlist");
        }
        public IActionResult OnGetRemoveFromWishlist(int gameId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToPage("/Error", new { errorMessage = "Пользователь не найден." });
            }

            var game = _gamesRepository.GetById(gameId);
            if (game == null)
            {
                return RedirectToPage("/Error", new { errorMessage = "Нет игры с таким ID." });
            }

            var wishlist = _wishlistRepository.GetByUserId(userId);
            if (wishlist == null || !wishlist.WishlistGames.Any(g => g.Game.Id == gameId))
            {
                return RedirectToPage("/Error", new { errorMessage = "Игры нет в желаемом." });
            }

            _wishlistRepository.RemoveFromWishlist(game, userId);
            return RedirectToPage("/Wishlist");
        }
    }
}
