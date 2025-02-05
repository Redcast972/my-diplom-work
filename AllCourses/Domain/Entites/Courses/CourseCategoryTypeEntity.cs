using System.ComponentModel.DataAnnotations;

namespace AllCourses.Domain.Entites.Courses
{
    public class CourseCategoryTypeEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Категория не должна быть пустой")]
        [MaxLength(50)]
        public string CourseCategoryType { get; set; }
    }
}
