namespace Xpymb.Telegram.Bot.Data.Entities;

public class UserEntity : BaseEntity
{
    public long TelegramId { get; set; }
    
    public string Username { get; set; }
}