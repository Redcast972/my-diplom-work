using System.ComponentModel.DataAnnotations;

namespace Hexagon.Models.News
{
    public class NewsViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле заголовка не должно быть пустым.")]
        [Display(Name = "Загаловок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле контента не должно быть пустым.")]
        [Display(Name = "Контент")]
        public string Discription { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] ImageData { get; set; }
    }
}
