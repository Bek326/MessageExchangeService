using Dapper;
using MessageExchangeService.Models;
using Npgsql;

namespace MessageExchangeService.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly string _connectionString;

    public MessageRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task SaveMessageAsync(Message message)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var query = "INSERT INTO Messages (Content, Timestamp, OrderNumber) VALUES (@Content, @Timestamp, @OrderNumber)";
            await connection.ExecuteAsync(query, message);
        }
    }

    public async Task<List<Message>> GetMessagesAsync(DateTime from, DateTime to)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Messages WHERE Timestamp BETWEEN @From AND @To";
            var messages = await connection.QueryAsync<Message>(query, new { From = from, To = to });
            return messages.ToList();
        }
    }
}