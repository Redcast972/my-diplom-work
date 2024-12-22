using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AllCourses.Domain.Entites
{
    public class UserAvatarEntity
    {
        [Key]
        public int AvatarId { get; set; } // Уникальный идентификатор для аватарки

        [Required]
        public string UserId { get; set; } = string.Empty; // Связь с пользователем

        [Required]
        public byte[] AvatarData { get; set; } = Array.Empty<byte>(); // Данные изображения в байтах

        [Required]
        public string ContentType { get; set; } = "image/jpeg"; // MIME-тип изображения (например, image/jpeg)
    }
}
