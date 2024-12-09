using AllCourses.Domain.Entites;
using AllCourses.Domain.Repositories.Abstract;

namespace AllCourses.Domain.Repositories.EntityFramevork
{
    public class EFNewsRepository : INewsRepository
    {
        public Task CreateNewsAsync(NewsEntity news)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNewsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NewsEntity>> GetAllNewsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<NewsEntity> GetNewsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNewsAsync(NewsEntity news)
        {
            throw new NotImplementedException();
        }
    }
}
