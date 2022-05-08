using Telegram.Bot.Types;
using Xpymb.Telegram.Bot.Models;

namespace Xpymb.Telegram.Bot.Infrastructure;

public interface IBotService
{
    Task ConfigureWebhook();
    Task SendMessageAsync(SendMessageModel model);
    Task HandleMessageAsync(Update update);
}