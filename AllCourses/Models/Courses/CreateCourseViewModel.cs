using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class CreateCourseViewModel
    {
        [Required(ErrorMessage = "Поле заголовка не должно быть пустым.")]
        [Display(Name = "Загаловок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле контента не должно быть пустым.")]
        [Display(Name = "Контент")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Поле типа цены не должно быть пустым.")]
        [Display(Name = "Тип цены")]
        public string CoursePriceType { get; set; }

        [Required(ErrorMessage = "Поле типа курса не должно быть пустым.")]
        [Display(Name = "Тип курса")]
        public string CourseCategoryType { get; set; }

        [Required(ErrorMessage = "Вы не выбрали изображение.")]
        public IFormFile ImageFile { get; set; }
    }
}
