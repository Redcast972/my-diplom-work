using Hexagon.Domain.Entites;
using Hexagon.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Domain.Repositories.EntityFramevork
{
    public class EFNewsRepository : INewsRepository
    {
        private HexagonDbContext _context;

        public EFNewsRepository(HexagonDbContext context)
        {
            _context = context;    
        }
        public async Task CreateNewsAsync(NewsEntity news)
        {
            if (news == null)
            {
                throw new ArgumentNullException(nameof(news));
            }

            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNewsAsync(Guid id)
        {
            var news = await GetNewsByIdAsync(id);
            if (news == null)
            {
                throw new KeyNotFoundException("News not found");
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsEntity>> GetAllNewsAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<NewsEntity> GetNewsByIdAsync(Guid id)
        {
            return await _context.News.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateNewsAsync(NewsEntity news)
        {
            if (news == null)
                throw new ArgumentNullException(nameof(news));

            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }
    }
}
