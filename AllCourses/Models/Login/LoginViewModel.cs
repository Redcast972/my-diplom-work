using System.ComponentModel.DataAnnotations;

namespace Hexagon.Models.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле логина не должно быть пустым.")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле пароля не должно быть пустым.")]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
