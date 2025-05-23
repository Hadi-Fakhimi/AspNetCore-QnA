using Microsoft.EntityFrameworkCore;
using Q_A_Example.Context;
using Q_A_Example.Models;
using Q_A_Example.Services.Interfaces;

namespace Q_A_Example.Services.Implementations
{
    public class MessageService:IMessageService
    {
        #region Constructor

        private readonly AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task<List<Message>> GetMessages()
        {
            var allMessage = await _context.Messages.AsQueryable()
                .Include(m => m.User)
                .Include(m => m. Replies)
                .ThenInclude(r => r.User)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();

            var lookup = allMessage.ToLookup(m => m.ParentMessageId);

            foreach (var message in allMessage)
            {
                message.Replies = lookup[message.Id].ToList();
            }

            return lookup[null].ToList();
        }

        public async Task<Message> AddMessage(string content, int? parentMessageId, int userId)
        {
            var message = new Message
            {
                Content = content,
                ParentMessageId = parentMessageId,
                UserId = userId
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }
    }
}
