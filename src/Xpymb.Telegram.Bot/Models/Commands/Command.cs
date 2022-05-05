using Telegram.Bot;
using Telegram.Bot.Types;

namespace Xpymb.Telegram.Bot.Models.Commands;

public abstract class Command
{
    public abstract string Name { get; }
    public abstract string Keyword { get; set; }

    public abstract Task ExecuteAsync(ITelegramBotClient client, Update update, IServiceProvider serviceProvider);

    public bool Contains(string keyword)
    {
        return Keyword == keyword;
    }
}