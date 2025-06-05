using System.ComponentModel.DataAnnotations;

namespace Hexagon.Domain.Entites
{
    public class NewsEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Заголовок не должен быть пустым")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описание не должен быть пустым")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Картинка в виде массива байтов
        public byte[] ImageData { get; set; }

        // MIME-тип картинки (например, image/png)
        [MaxLength(50)]
        public string ImageContentType { get; set; }
    }
}
