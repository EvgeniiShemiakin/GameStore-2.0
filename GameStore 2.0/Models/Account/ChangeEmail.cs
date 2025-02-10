using System.ComponentModel.DataAnnotations;

namespace GameStore_2._0.Models.Account
{
    public class ChangeEmail
    {
        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты")]
        public string Email { get; set; }
        public string? UserId { get; set; }

    }
}
