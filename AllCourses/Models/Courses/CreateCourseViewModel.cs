using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class CreateCourseViewModel
    {
        [Required(ErrorMessage = "Поле заголовка не должно быть пустым.")]
        [Display(Name = "Загаловок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле описания не должно быть пустым.")]
        [Display(Name = "Описание")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Поле типа цены не должно быть пустым.")]
        [Display(Name = "Тип цены")]
        public List<SelectListItem> CoursePrices { get; set; } = new();

        [Required(ErrorMessage = "Поле типа курса не должно быть пустым.")]
        [Display(Name = "Тип курса")]
        public List<SelectListItem> CourseCategories { get; set; } = new();

        [Required(ErrorMessage = "Вы не выбрали изображение.")]
        public IFormFile ImageFile { get; set; }
    }
}
