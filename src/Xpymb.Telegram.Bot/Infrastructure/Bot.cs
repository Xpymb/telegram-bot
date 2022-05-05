using Telegram.Bot;
using Xpymb.Telegram.Bot.Infrastructure.Entities;
using Xpymb.Telegram.Bot.Models.Commands;

namespace Xpymb.Telegram.Bot.Infrastructure;

public class Bot
{
    public ITelegramBotClient? Client { get; init; }
    public List<Command> ListCommands { get; private set; }
    
    private BotConfiguration _botConfiguration { get; init; }
    
    public Bot(IConfiguration configuration)
    {
        _botConfiguration = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        
        Client = new TelegramBotClient(_botConfiguration.Token);
        
        ListCommands = new List<Command>
        {
            new StartCommand(),
            new GetMyIdCommand(),
            new GetMyRegDateCommand(),
            new DayCommand(),
            new TimeCommand(),
            new DateCommand(),
        };
        
        Client.SetWebhookAsync($"{_botConfiguration.WebhookUrl}/message/update");
    }
}