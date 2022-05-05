using Xpymb.Telegram.Bot.Models;

namespace Xpymb.Telegram.Bot.Infrastructure;

public interface IBotService
{
    Task SendMessage(SendMessageModel model);
    void BotConfigure();
    Bot GetBot();
}