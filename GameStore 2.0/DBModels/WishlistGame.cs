namespace GameStore_2._0.DBModels;

using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(WishlistId), nameof(GameId))]
public class WishlistGame
{
    public Guid WishlistId { get; set; }

    public int GameId { get; set; }

    public DateOnly DateAdded { get; set; }

    public Wishlist Wishlist { get; set; }
    public Game Game { get; set; }

    public WishlistGame()
    {
        DateAdded = DateOnly.FromDateTime(DateTime.Now);
    }
}
