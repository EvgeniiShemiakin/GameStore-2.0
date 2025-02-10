using System.ComponentModel.DataAnnotations;

namespace GameStore_2._0.Models.Account
{
    public class ChangePhone
    {
        [Required(ErrorMessage = "Не указан номер телефона")]
        [Phone(ErrorMessage = "Некорректный формат номера телефона")]
        [StringLength(16, MinimumLength = 11, ErrorMessage = "Некорректная длина номера телефона")]
        public string Phone { get; set; }
        public string? UserId { get; set; }
    }
}
