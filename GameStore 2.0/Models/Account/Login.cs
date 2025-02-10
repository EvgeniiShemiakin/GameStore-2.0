using System.ComponentModel.DataAnnotations;

namespace GameStore_2._0.Models.Account
{
    public class Login
    {
        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 16 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
