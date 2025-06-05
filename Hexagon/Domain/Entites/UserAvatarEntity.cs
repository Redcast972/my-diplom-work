using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Hexagon.Domain.Entites
{
    public class UserAvatarEntity
    {
        [Key]
        public Guid ImageId { get; set; } // Уникальный идентификатор для аватарки

        [Required]
        public Guid UserId { get; set; } // Связь с пользователем

        [Required]
        public string FileName { get; set; } // Имя картинки

        [Required]
        public byte[] ImageData { get; set; } = Array.Empty<byte>(); // Данные изображения в байтах

        [Required]
        public string ContentType { get; set; } = "image/jpeg"; // MIME-тип изображения (например, image/jpeg)
    }
}
