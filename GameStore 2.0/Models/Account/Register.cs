using System.ComponentModel.DataAnnotations;

namespace GameStore_2._0.Models.Account
{
    public class Register
    {
        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 16 символов")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Не указан номер телефона")]
        [Phone(ErrorMessage = "Некорректный формат номера телефона")]
        [StringLength(16, MinimumLength = 11, ErrorMessage = "Некорректная длина номера телефона")]
        public string Phone { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
