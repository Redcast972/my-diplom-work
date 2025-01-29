using System.ComponentModel.DataAnnotations;

namespace AllCourses.Areas.Admin.Models
{
    public class CreateNewsViewModel
    {
        [Required(ErrorMessage = "Поле заголовка не должно быть пустым.")]
        [Display(Name = "Загаловок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле контента не должно быть пустым.")]       
        [Display(Name = "Контент")]
        public string Discription { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
