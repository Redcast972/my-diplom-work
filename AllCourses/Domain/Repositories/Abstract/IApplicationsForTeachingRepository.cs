using AllCourses.Domain.Entites.ApplicationsForTeaching;

namespace AllCourses.Domain.Repositories.Abstract
{
    public interface IApplicationsForTeachingRepository
    {
        Task CreateApplicationForTeachingAsync(ApplicationForTeachingEntity application);
        Task DeleteApplicationForTeachingAsync(Guid id);
        Task<List<ApplicationForTeachingEntity>> GetAllApplicationsForTeachingAsync();
        Task<ApplicationForTeachingEntity> GetApplicationForTeachingByIdAsync(Guid id);
        Task UpdateApplicationForTeachingAsync(ApplicationForTeachingEntity application);
    }
}