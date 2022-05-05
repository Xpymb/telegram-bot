using Telegram.Bot;
using Telegram.Bot.Types;

namespace Xpymb.Telegram.Bot.Models.Commands;

public class DayCommand : Command
{
    public override string Name { get; } = "Get current day";
    public override string Keyword { get; set; } = "/day";

    public override async Task ExecuteAsync(ITelegramBotClient client, Update update, IServiceProvider serviceProvider)
    {
        await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: $"Текущий день недели: {DateTime.Now.ToString("dddd")}");
    }
}