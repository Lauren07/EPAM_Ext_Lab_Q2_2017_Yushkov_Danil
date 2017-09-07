using System.ComponentModel.DataAnnotations;

namespace FileStorage.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Не заполнен логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не введен пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}