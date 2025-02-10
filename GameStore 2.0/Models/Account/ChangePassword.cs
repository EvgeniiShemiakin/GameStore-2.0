using System.ComponentModel.DataAnnotations;

namespace GameStore_2._0.Models.Account
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 16 символов")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmNewPassword { get; set; }
        public string? UserId { get; set; }

    }
}
