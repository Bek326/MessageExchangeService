namespace MessageExchangeService.Models;

public class Message
{
    public int Id { get; init; }
    public string Content { get; init; }
    public DateTime Timestamp { get; set; }
    public int OrderNumber { get; init; }
}