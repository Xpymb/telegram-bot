using Telegram.Bot;
using Telegram.Bot.Types;
using Xpymb.Telegram.Bot.Infrastructure;
using Xpymb.Telegram.Bot.Infrastructure.Entities;

namespace Xpymb.Telegram.Bot.Models.Commands;

public class StartCommand : Command
{
    public override string Name { get; } = "Start Command";
    public override string Keyword { get; set; } = "/start";

    public override async Task ExecuteAsync(ITelegramBotClient client, Update update, IServiceProvider serviceProvider)
    {
        var userService = serviceProvider.GetService<IUserService>();
        
        var telegramUser = update.Message.From;

        if (await userService.GetAsync(telegramUser.Id) is not null)
        {
            await client.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: $"Вы уже зарегистрированы");
            
            return;
        }
        
        var userCreate = new UserCreate
        {
            TelegramId = telegramUser.Id,
            Username = telegramUser.Username
        };

        await userService.CreateAsync(userCreate);

        await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: $"Вы успешно зарегистрированы");
    }
}