using System.ComponentModel.DataAnnotations;

namespace AllCourses.Domain.Entites.Courses
{
    public class CourseEntity
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле заголовка не должно быть пустым.")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле контента не должно быть пустым.")]
        [Display(Name = "Контент")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Поле автора не должно быть пустым.")]
        [Display(Name = "Автор")]
        public string Author { get; set; }
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "Поле категории курса не должно быть пустым.")]
        [Display(Name = "Категория кура")]
        public string CourseCategoryType { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] ImageData { get; set; }
        public List<LessonEntity> Lessons { get; set; }
        public List<MessageEntity> Commentaries { get; set; }
        public List<TestEntity> Tests { get; set; }
        public List<Guid> Students { get; set; }
    }

    public class LessonEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public byte[] ImageData { get; set; }
        public string[] LinksToVideoTutorials { get; set; }
    }

    public class TestEntity
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public int CorrectAnswerNumber { get; set; }
    }
}
