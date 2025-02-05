using AllCourses.Domain.Entites.Courses;

namespace AllCourses.Domain.Repositories.Abstract
{
    public interface ICoursePriceTypesRepository
    {
        Task CreateCoursePticeTypeAsync(CoursePriceTypeEntity coursePticeTypeEntity);
        Task DeleteCoursePticeTypeAsync(Guid id);
        Task<List<CoursePriceTypeEntity>> GetAllCoursePticeTypesAsync();
        Task<CoursePriceTypeEntity> GetCoursePticeTypeByIdAsync(Guid id);
        Task UpdateCoursePticeTypeAsync(CoursePriceTypeEntity coursePticeTypeEntity);
    }
}