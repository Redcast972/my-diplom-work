using AllCourses.Domain.Entites.Courses;
using AllCourses.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AllCourses.Domain.Repositories.EntityFramevork
{
    public class EFCoursePriceTypesRepository : ICoursePriceTypesRepository
    {
        private AllCoursesDbContext _context;

        public EFCoursePriceTypesRepository(AllCoursesDbContext context)
        {
            _context = context;
        }

        public async Task<List<CoursePriceTypeEntity>> GetAllCoursePticeTypesAsync()
        {
            var coursePriceTypes = await _context.CoursePriceTypes.ToListAsync();

            return coursePriceTypes;
        }

        public async Task<CoursePriceTypeEntity> GetCoursePticeTypeByIdAsync(Guid id)
        {
            return await _context.CoursePriceTypes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateCoursePticeTypeAsync(CoursePriceTypeEntity coursePticeTypeEntity)
        {
            if (coursePticeTypeEntity == null)
                throw new ArgumentNullException(nameof(coursePticeTypeEntity));

            await _context.CoursePriceTypes.AddAsync(coursePticeTypeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoursePticeTypeAsync(CoursePriceTypeEntity coursePticeTypeEntity)
        {
            if (coursePticeTypeEntity == null)
                throw new ArgumentNullException(nameof(coursePticeTypeEntity));

            _context.CoursePriceTypes.Update(coursePticeTypeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoursePticeTypeAsync(Guid id)
        {
            var coursePticeTypeEntity = await GetCoursePticeTypeByIdAsync(id);
            if (coursePticeTypeEntity == null)
                throw new KeyNotFoundException("CoursePticeType not found");

            _context.CoursePriceTypes.Remove(coursePticeTypeEntity);
            await _context.SaveChangesAsync();
        }

    }
}
