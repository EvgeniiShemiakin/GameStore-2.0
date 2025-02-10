using Microsoft.AspNetCore.Identity;

namespace GameStore_2._0.DBModels
{
    public class User : IdentityUser
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public decimal BuySum { get; set; } = 0;
        public int Discount => GetDiscount();

        public int GetDiscount() //накопительная скидка 15% максимум
        {
            if (BuySum >= 15000)
                return 15;

            return (int)BuySum / 1000;
        }
    }
}