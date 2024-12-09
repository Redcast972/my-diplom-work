using System.ComponentModel.DataAnnotations;

namespace AllCourses.Domain.Entites
{
    public class NewsEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Изображение")]
        public ImageEntity Image { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime Date { get; set; }
    }
}
