using AllCourses.Domain.Entites;

namespace AllCourses.Domain.Repositories.Abstract
{
    public interface IMessageRepository
    {
        // Создать новое сообщение
        Task CreateMessageAsync(MessageEntity message);

        // Получить сообщение по идентификатору
        Task<MessageEntity> GetMessageByIdAsync(Guid id);

        Task<IEnumerable<MessageEntity>> GetMessagesByUserIdAsync(Guid userId);

        // Получить все сообщения
        Task<IEnumerable<MessageEntity>> GetAllMessagesAsync();

        // Обновить сообщение
        Task UpdateMessageAsync(MessageEntity message);

        // Удалить сообщение по идентификатору
        Task DeleteMessageAsync(Guid id);
    }

}
