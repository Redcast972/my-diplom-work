using AllCourses.Domain.Entites.Courses;

namespace AllCourses.Domain.Repositories.Abstract
{
    public interface ICourseCategoryTypeRepository
    {
        Task CreateCourseCategoryTypeAsync(CourseCategoryTypeEntity courseCategoryTypeEntity);
        Task DeleteCourseCategoryTypeAsync(Guid id);
        Task<List<CourseCategoryTypeEntity>> GetAllCourseCategoryTypesAsync();
        Task<CourseCategoryTypeEntity> GetCourseCategoryTypeByIdAsync(Guid id);
    }
}