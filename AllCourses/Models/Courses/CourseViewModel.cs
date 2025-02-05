using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле заголовка не должно быть пустым.")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле контента не должно быть пустым.")]
        [Display(Name = "Контент")]
        public string Discription { get; set; }
        public string Author { get; set; }
        public string CoursePriceType { get; set; }
        public string CourseCategoryType { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] ImageData { get; set; }
    }
}
