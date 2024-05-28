using MessageExchangeService.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageExchangeService.Data;

public class MessageContext: DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }

    public DbSet<Message> Messages { get; init; }
}