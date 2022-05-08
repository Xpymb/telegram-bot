using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Xpymb.Telegram.Bot.Infrastructure;
using Xpymb.Telegram.Bot.Models;

namespace Xpymb.Telegram.Bot.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IBotService _botService;

    public MessageController(IServiceProvider serviceProvider, IBotService botService)
    {
        _serviceProvider = serviceProvider;
        _botService = botService;
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Update([FromBody]Update model)
    {
        await _botService.HandleMessageAsync(model);

        return Ok();
    }

    [HttpPost]
    public IActionResult Send([FromBody] SendMessageModel model)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        _botService.SendMessageAsync(model);
        
        return NoContent();
    }
}