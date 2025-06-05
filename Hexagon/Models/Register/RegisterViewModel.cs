using System.ComponentModel.DataAnnotations;

namespace Hexagon.Models.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле Имя пользователя обязательно для заполнения.")]
        [StringLength(255, ErrorMessage = "Имя пользователя должно быть длиной от 3 до 255 символов.", MinimumLength = 3)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле электронная почта обязательно для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должно быть длиной от 6 и более символов.", MinimumLength = 6)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле подтверждение пароля обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }
}
