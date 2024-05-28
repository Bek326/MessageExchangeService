using MessageExchangeService.Hubs;
using MessageExchangeService.Models;
using MessageExchangeService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MessageExchangeService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _repository;
    private readonly IHubContext<MessageHub> _hubContext;

    public MessagesController(IMessageRepository repository, IHubContext<MessageHub> hubContext)
    {
        _repository = repository;
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] Message message)
    {
        message.Timestamp = DateTime.UtcNow;
        await _repository.SaveMessageAsync(message);
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetMessages([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var messages = await _repository.GetMessagesAsync(from, to);
        return Ok(messages);
    }
}