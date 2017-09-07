using System.ComponentModel.DataAnnotations;

namespace FileStorage.Models
{
    public class UserChangePasswordViewModel
    {

        [Required(ErrorMessage = "Не введен старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Не введен новый пароль")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Минимальная длина пароля 4 символа")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Не подтвержден новый пароль")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmNewPassword { get; set; }

    }
}