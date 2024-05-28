using MessageExchangeService.Models;

namespace MessageExchangeService.Repositories;

public interface IMessageRepository
{
    Task SaveMessageAsync(Message message);
    Task<List<Message>> GetMessagesAsync(DateTime from, DateTime to);
}