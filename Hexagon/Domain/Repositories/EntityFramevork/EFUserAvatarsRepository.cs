using Hexagon.Domain.Entites;
using Hexagon.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Domain.Repositories.EntityFramevork
{
    public class EFUserAvatarsRepository : IUserAvatarsRepository
    {
        private HexagonDbContext _context;
        public EFUserAvatarsRepository(HexagonDbContext context)
        {
            _context = context;
        }
        public async Task<byte[]> GetImageByUserIdAsync(Guid userId)
        {
            var imageEntity = await _context.UsersAvatars.FirstOrDefaultAsync(img => img.UserId == userId);

            if (imageEntity == null)
            {
                throw new KeyNotFoundException("Image not found in the database.");
            }

            return imageEntity.ImageData; // Возвращаем массив байтов (само изображение)
        }

        public async Task SaveDefaultAvatarAsync(string contentType, Guid userId)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "defaultProfileIcon.png");
            byte[] imageBytes = File.ReadAllBytes(filePath);
           

            // Создание сущности для хранения изображения
            var avatarEntity = new UserAvatarEntity
            {
                ImageId = Guid.NewGuid(),
                UserId = userId,
                FileName = "Avatar",
                ImageData = imageBytes,
                ContentType = contentType,
            };

            // Добавление сущности в контекст
            _context.UsersAvatars.Add(avatarEntity);

            // Сохранение изменений в базе данных
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveAvatarAsync(IFormFile file, Guid userId)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var imageData = memoryStream.ToArray();

            var avatarEntity = new UserAvatarEntity
            {
                ImageId = Guid.NewGuid(),
                UserId = userId,
                FileName = file.FileName,
                ImageData = imageData,
                ContentType = file.ContentType
            };

            _context.UsersAvatars.Add(avatarEntity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
