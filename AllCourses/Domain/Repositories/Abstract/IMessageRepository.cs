using AllCourses.Domain.Entites;

namespace AllCourses.Domain.Repositories.Abstract
{
    public interface IMessageRepository
    {
        // Создать новое сообщение
        Task CreateMessageAsync(MessageEntity message);

        // Получить сообщение по идентификатору
        Task<MessageEntity> GetMessageByIdAsync(string id);

        Task<IEnumerable<MessageEntity>> GetMessagesByUserIdAsync(string userId);

        // Получить все сообщения
        Task<IEnumerable<MessageEntity>> GetAllMessagesAsync();

        // Обновить сообщение
        Task UpdateMessageAsync(MessageEntity message);

        // Удалить сообщение по идентификатору
        Task DeleteMessageAsync(string id);
    }

}
