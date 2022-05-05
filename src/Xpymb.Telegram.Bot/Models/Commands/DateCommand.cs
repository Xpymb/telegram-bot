using Telegram.Bot;
using Telegram.Bot.Types;

namespace Xpymb.Telegram.Bot.Models.Commands;

public class DateCommand : Command
{
    public override string Name { get; } = "Get current date";
    public override string Keyword { get; set; } = "/date";

    public override async Task ExecuteAsync(ITelegramBotClient client, Update update, IServiceProvider serviceProvider)
    {
        await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: $"Текущая дата: {DateTime.Now.Date.ToString("d")}");
    }
}