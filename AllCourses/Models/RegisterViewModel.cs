using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Вы не выбрали роль.")]
        [Display(Name = "Роль")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Поле логина не должно быть пустым.")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле почты не должно быть пустым.")]
        [UIHint("email")]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароля не должно быть пустым.")]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
