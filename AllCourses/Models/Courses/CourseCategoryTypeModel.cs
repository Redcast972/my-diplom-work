using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class CourseCategoryTypeModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле категории курса не должно быть пустым.")]
        [Display(Name = "Категория курса")]
        public string Category { get; set; }
    }
}
