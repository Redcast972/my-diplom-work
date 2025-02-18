using AllCourses.Domain.Entites.ApplicationsForTeaching;
using AllCourses.Domain.Entites.Courses;
using AllCourses.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AllCourses.Domain.Repositories.EntityFramevork
{
    public class EFApplicationsForTeachingRepository : IApplicationsForTeachingRepository
    {
        private AllCoursesDbContext _context;
        public EFApplicationsForTeachingRepository(AllCoursesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationForTeachingEntity>> GetAllApplicationsForTeachingAsync()
        {
            var application = await _context.ApplicationsForTeaching.ToListAsync();

            return application;
        }

        public async Task<ApplicationForTeachingEntity> GetApplicationForTeachingByIdAsync(Guid id)
        {
            return await _context.ApplicationsForTeaching.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ApplicationForTeachingEntity> GetApplicationForTeachingByUserNameAsync(string username)
        {
            return await _context.ApplicationsForTeaching
            .Where(m => m.UserName == username)
            .OrderByDescending(m => m.CreatedAt) // Предполагаем, что есть поле CreatedAt
            .FirstOrDefaultAsync();
        }

        public async Task CreateApplicationForTeachingAsync(ApplicationForTeachingEntity application)
        {
            if (application == null)
                throw new ArgumentNullException(nameof(application));

            await _context.ApplicationsForTeaching.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateApplicationForTeachingAsync(ApplicationForTeachingEntity application)
        {
            if (application == null)
                throw new ArgumentNullException(nameof(application));

            _context.ApplicationsForTeaching.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicationForTeachingAsync(Guid id)
        {
            var application = await GetApplicationForTeachingByIdAsync(id);
            if (application == null)
                throw new KeyNotFoundException("Application for teaching not found");

            _context.ApplicationsForTeaching.Remove(application);
            await _context.SaveChangesAsync();
        }
    }
}
