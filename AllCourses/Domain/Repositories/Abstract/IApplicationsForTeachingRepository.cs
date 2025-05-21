using Hexagon.Domain.Entites.ApplicationsForTeaching;

namespace Hexagon.Domain.Repositories.Abstract
{
    public interface IApplicationsForTeachingRepository
    {
        Task<ApplicationForTeachingEntity> GetApplicationForTeachingByUserNameAsync(string username);
        Task CreateApplicationForTeachingAsync(ApplicationForTeachingEntity application);
        Task DeleteApplicationForTeachingAsync(Guid id);
        Task<IEnumerable<ApplicationForTeachingEntity>> GetAllApplicationsForTeachingAsync();
        Task<ApplicationForTeachingEntity> GetApplicationForTeachingByIdAsync(Guid id);
        Task UpdateApplicationForTeachingAsync(ApplicationForTeachingEntity application);
    }
}