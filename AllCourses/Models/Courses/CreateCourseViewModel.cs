using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class CreateCourseViewModel
    {
        [Required(ErrorMessage = "Поле название курса не должно быть пустым.")]
        [Display(Name = "Название курса")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле описания не должно быть пустым.")]
        [Display(Name = "Описание")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Поле типа курса не должно быть пустым.")]
        [Display(Name = "Тип курса")]

        public string CourseCategory { get; set; }

        public List<SelectListItem> CourseCategories { get; set; } = new();

        [Required(ErrorMessage = "Вы не выбрали изображение.")]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Укажите количество уроков")]
        [Display(Name = "Количество уроков")]
        [Range(1, 100, ErrorMessage = "Количество уроков должно быть от 1 до 100")]
        public int LessonsCount { get; set; }

        [Display(Name = "Уроки курса")]
        public List<LessonViewModel> Lessons { get; set; } = new();
    }

    public class LessonViewModel
    {
        [Required(ErrorMessage = "Поле название урока не должно быть пустым.")]
        [Display(Name = "Название урока")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле содержания урока не должно быть пустым.")]
        [Display(Name = "Содержание урока")]
        public string Content { get; set; }

        [Display(Name = "Дополнительные материалы")]
        public List<IFormFile> Attachments { get; set; } = new();

        [Display(Name = "Видео урока")]
        public IFormFile VideoFile { get; set; }

        [Display(Name = "Порядковый номер урока")]
        [Range(1, 1000, ErrorMessage = "Номер урока должен быть положительным")]
        public int OrderNumber { get; set; }
    }
}
