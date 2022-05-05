using Telegram.Bot;
using Xpymb.Telegram.Bot.Models;

namespace Xpymb.Telegram.Bot.Infrastructure;

public class BotService : IBotService
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private Bot? _bot;

    public BotService(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    public async Task SendMessage(SendMessageModel model)
    {
        if (_bot is null) BotConfigure();

        var users = _userService.GetAll();

        foreach (var user in users)
        {
            await _bot.Client.SendTextMessageAsync(
                chatId: user.TelegramId,
                text: model.Text);
        }
    }

    public void BotConfigure()
    {
        _bot = new Bot(_configuration);
    }

    public Bot GetBot()
    {
        if (_bot is not null) return _bot;
        
        BotConfigure();
        return _bot;
    }
}