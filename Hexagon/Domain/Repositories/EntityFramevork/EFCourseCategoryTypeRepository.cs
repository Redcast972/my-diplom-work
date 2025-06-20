﻿using Hexagon.Domain.Entites.Courses;
using Hexagon.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Domain.Repositories.EntityFramevork
{
    public class EFCourseCategoryTypeRepository : ICourseCategoryTypeRepository
    {
        private HexagonDbContext _context;
        public EFCourseCategoryTypeRepository(HexagonDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseCategoryTypeEntity>> GetAllCourseCategoryTypesAsync()
        {
            var courseCategoryTypes = await _context.CourseCategoryTypes.ToListAsync();

            return courseCategoryTypes;
        }

        public async Task<CourseCategoryTypeEntity> GetCourseCategoryTypeByIdAsync(Guid id)
        {
            return await _context.CourseCategoryTypes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateCourseCategoryTypeAsync(CourseCategoryTypeEntity courseCategoryTypeEntity)
        {
            if (courseCategoryTypeEntity == null)
                throw new ArgumentNullException(nameof(courseCategoryTypeEntity));

            await _context.CourseCategoryTypes.AddAsync(courseCategoryTypeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseCategoryTypeAsync(Guid id)
        {
            var courseCategoryTypeEntity = await GetCourseCategoryTypeByIdAsync(id);
            if (courseCategoryTypeEntity == null)
                throw new KeyNotFoundException("CourseCategoryType not found");

            _context.CourseCategoryTypes.Remove(courseCategoryTypeEntity);
            await _context.SaveChangesAsync();
        }
    }
}
