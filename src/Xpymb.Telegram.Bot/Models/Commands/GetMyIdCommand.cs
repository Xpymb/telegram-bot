using Telegram.Bot;
using Telegram.Bot.Types;
using Xpymb.Telegram.Bot.Infrastructure;
using Xpymb.Telegram.Bot.Infrastructure.Entities;

namespace Xpymb.Telegram.Bot.Models.Commands;

public class GetMyIdCommand : Command
{
    public override string Name { get; } = "Get ID";
    public override string Keyword { get; set; } = "/myid";

    public override async Task ExecuteAsync(
        ITelegramBotClient client, 
        Update update, 
        IServiceProvider serviceProvider)
    {
        var userService = serviceProvider.GetService<IUserService>();

        var telegramUser = update.Message.From;

        var dbUser = await userService.GetAsync(telegramUser.Id);

        if (dbUser is null)
        {
            var userCreate = new UserCreate
            {
                Username = telegramUser.Username,
                TelegramId = telegramUser.Id,
            };

            await userService.CreateAsync(userCreate);
            
            dbUser = await userService.GetAsync(telegramUser.Id);

            await client.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: $"Вы успешно зарегистрированы, ваш id: {dbUser.Id}");
            
            return;
        }
        
        await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
            text: $"Ваш id = {dbUser.Id}");
    }
}