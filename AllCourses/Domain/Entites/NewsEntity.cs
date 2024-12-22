using System.ComponentModel.DataAnnotations;

namespace AllCourses.Domain.Entites
{
    public class NewsEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
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
