namespace Xpymb.Telegram.Bot.Infrastructure.Entities;

public class User
{
    public Guid Id { get; set; }
    
    public long TelegramId { get; set; }
    public string Username { get; set; }
    
    public DateTime DateCreated { get; set; }
}