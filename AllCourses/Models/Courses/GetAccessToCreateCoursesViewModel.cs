using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class GetAccessToCreateCoursesViewModel
    {
        [Required(ErrorMessage = "Поле описания не должно быть пустым.")]
        [Display(Name = "Опиание")]
        public string Discription { get; set; }
    }
}
