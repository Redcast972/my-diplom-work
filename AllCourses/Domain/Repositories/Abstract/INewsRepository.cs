using AllCourses.Domain.Entites;

namespace AllCourses.Domain.Repositories.Abstract
{
    public interface INewsRepository
    {
        // Добавить новую новость
        Task CreateNewsAsync(NewsEntity news);

        // Получить новость по идентификатору
        Task<NewsEntity> GetNewsByIdAsync(Guid id);

        // Получить все новости
        Task<IEnumerable<NewsEntity>> GetAllNewsAsync();

        // Обновить новость
        Task UpdateNewsAsync(NewsEntity news);

        // Удалить новость по идентификатору
        Task DeleteNewsAsync(Guid id);
    }
}
