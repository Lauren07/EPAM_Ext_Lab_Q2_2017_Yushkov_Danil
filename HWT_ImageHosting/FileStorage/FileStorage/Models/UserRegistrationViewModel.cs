using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FileStorage.Models
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "Не указан логин аккаунта")]
        [Remote("CheckExistingLogin", "Account", ErrorMessage = "Данный логин уже занят")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не введен пароль")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Минимальная длина пароля 4 символа")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не подтвержден пароль")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
    }
}