using Hexagon.Domain.Entites;
using Hexagon.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Domain.Repositories.EntityFramevork
{
    public class EFMessageRepository : IMessageRepository
    {
        private HexagonDbContext _context;
        public EFMessageRepository(HexagonDbContext context)
        {
            _context = context;
        }

        public async Task CreateMessageAsync(MessageEntity message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        // Получить сообщение по идентификатору
        public async Task<MessageEntity> GetMessageByIdAsync(string id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        // Получить все сообщения
        public async Task<IEnumerable<MessageEntity>> GetAllMessagesAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        // Получить сообщения по пользователю
        public async Task<IEnumerable<MessageEntity>> GetMessagesByUserIdAsync(string userId)
        {
            return await _context.Messages
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }

        // Обновить сообщение
        public async Task UpdateMessageAsync(MessageEntity message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
        }

        // Удалить сообщение по идентификатору
        public async Task DeleteMessageAsync(string id)
        {
            var message = await GetMessageByIdAsync(id);
            if (message == null)
                throw new KeyNotFoundException("Message not found");

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }        
    }
}
