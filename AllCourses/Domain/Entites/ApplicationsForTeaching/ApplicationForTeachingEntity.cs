using System.ComponentModel.DataAnnotations;

namespace AllCourses.Domain.Entites.ApplicationsForTeaching
{
    public class ApplicationForTeachingEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Описание не должен быть пустым")]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Имя пользователя не должно быть пустым")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Почта пользователя не должен быть пустым")]
        public string UserEmail { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
