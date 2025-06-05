namespace Hexagon.Domain.Repositories.Abstract
{
    public interface IUserAvatarsRepository
    {
        Task<byte[]> GetImageByUserIdAsync(Guid userId);
        Task<bool> SaveAvatarAsync(IFormFile file, Guid userId);
        Task SaveDefaultAvatarAsync(string contentType, Guid userId);
    }
}