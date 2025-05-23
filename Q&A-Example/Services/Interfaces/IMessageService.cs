using Q_A_Example.Models;

namespace Q_A_Example.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessages();
        Task<Message> AddMessage(string content , int? parentMessageId,int userId);
    }
}
