using Telegram.Bot;
using Telegram.Bot.Types;

namespace Xpymb.Telegram.Bot.Models.Commands;

public class TimeCommand : Command
{
    public override string Name { get; } = "Get current time";
    public override string Keyword { get; set; } = "/time";

    public override async Task ExecuteAsync(ITelegramBotClient client, Update update, IServiceProvider serviceProvider)
    {
        await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: $"Текущее время: {DateTime.Now.ToShortTimeString()}");
    }
}