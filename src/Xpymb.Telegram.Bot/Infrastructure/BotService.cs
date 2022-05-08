using Telegram.Bot;
using Telegram.Bot.Types;
using Xpymb.Telegram.Bot.Infrastructure.Entities;
using Xpymb.Telegram.Bot.Models;
using Xpymb.Telegram.Bot.Models.Commands;

namespace Xpymb.Telegram.Bot.Infrastructure;

public class BotService : IBotService
{
    private readonly IUserService _userService;
    private readonly IServiceProvider _serviceProvider;
    private readonly BotConfiguration _botConfiguration;
    private readonly ITelegramBotClient _client;
    private List<Command> _listCommands;

    public BotService(IUserService userService, IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _userService = userService;
        _serviceProvider = serviceProvider;

        _botConfiguration = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        
        _client = new TelegramBotClient(_botConfiguration.Token);
        
        _listCommands = new List<Command>
        {
            new StartCommand(),
            new GetMyIdCommand(),
            new GetMyRegDateCommand(),
            new DayCommand(),
            new TimeCommand(),
            new DateCommand(),
        };
    }

    public async Task ConfigureWebhook()
    {
        await _client.SetWebhookAsync($"{_botConfiguration.WebhookUrl}/message/update");
    }
    
    public async Task SendMessageAsync(SendMessageModel model)
    {
        var users = _userService.GetAll();

        foreach (var user in users)
        {
            await _client.SendTextMessageAsync(
                chatId: user.TelegramId,
                text: model.Text);
        }
    }

    public async Task HandleMessageAsync(Update update)
    {
        foreach (var command in _listCommands.Where(x => x.Contains(update.Message.Text)))
        {
            await command.ExecuteAsync(_client, update, _serviceProvider);
        }
    }
}