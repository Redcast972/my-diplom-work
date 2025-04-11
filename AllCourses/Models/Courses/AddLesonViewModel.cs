using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class AddLesonViewModel
    {
        [Required(ErrorMessage = "Поле названия урока не должно быть пустым.")]
        [Display(Name = "Название урока")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле контента не должно быть пустым.")]
        [Display(Name = "Контент")]
        public string Discription { get; set; }

        [Display(Name = "Ссылка на видеоурок")]
        public string LinkToVideoTutorial { get; set; }

        [Required(ErrorMessage = "Вы не выбрали изображение.")]
        public IFormFile ImageFile { get; set; }
    }
}
